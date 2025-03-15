using Emuhub.Communication.Data.Auth;
using Emuhub.Domain.Entities.Users;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Infrastructure.Services.Authentication
{
    public class AuthService(ApplicationDbContext context, JwtTokenHandlerService jwtTokenService)
    {
        public async Task Register(RegisterRequest request)
        {
            var emailAndUserNameUnavailable = await DoesUserNameOrEmailAlreadyExists(request.UserName, request.Email);

            if (emailAndUserNameUnavailable)
                throw new ValidationErrorException([new { EmailOrUserName = "Email or user name are already in use" }]);

            var user = new User() { 
                Name = request.UserName,
                Email = request.Email,
            };
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.PasswordHash = hashedPassword;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<string> Login(LoginRequest request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user is null)
                throw new ResourceNotFoundException("User", "Invalid email or password");

            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);
            
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                throw new ResourceNotFoundException("User", "Invalid email or password");

            return jwtTokenService.CreateToken(user);
        }

        public async Task<bool> DoesUserNameOrEmailAlreadyExists(string userName, string email)
        {
            return await context.Users.AnyAsync(u => u.Name == userName || u.Email == email);
        }
    }
}
