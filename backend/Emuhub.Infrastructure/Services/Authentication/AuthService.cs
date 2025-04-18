using Emuhub.Communication.Data.Auth;
using Emuhub.Domain.Entities.Users;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Emuhub.Infrastructure.Services.Authentication
{
    public class AuthService(IUserRepository userRepository, JwtTokenHandlerService jwtTokenService)
    {
        public async Task<Guid> Register(RegisterRequest request)
        {
            var emailAndUserNameAvailable = !await userRepository.IsUserNameAndEmailAvailable(request.UserName, request.Email);

            if (!emailAndUserNameAvailable)
                throw new ValidationErrorException(new ValidationErrorItem("EmailOrUserName", "Email or user name are already in use"));

            var user = new User()
            {
                Name = request.UserName,
                Email = request.Email
            };
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.PasswordHash = hashedPassword;

            await userRepository.Add(user);
            return user.Id;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await userRepository.GetByEmail(request.Email);

            if (user is null)
                throw new ResourceNotFoundException("User", "Invalid email or password");

            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);
            
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                throw new ResourceNotFoundException("User", "Invalid email or password");

            return new LoginResponse()
            {
                UserId = user.Id,
                UserTokens = await CreateAndSaveNewUserTokens(user)
            };
        }

        public async Task<UserTokensResponse> RefreshToken(RefreshTokenRequest request)
        {
            var user = await userRepository.GetById(request.UserId);

            if (user is null)
                throw new ResourceNotFoundException("User", "Invalid user Id");
            if (request.RefreshToken != user.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
                throw new ResourceNotFoundException("RefreshToken", "Token invalid or expired");

            return await CreateAndSaveNewUserTokens(user);
        }

        private async Task<UserTokensResponse> CreateAndSaveNewUserTokens(User user)
        {
            var token = jwtTokenService.CreateToken(user);
            var refreshToken = JwtTokenHandlerService.CreateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await userRepository.Update(user);

            return new UserTokensResponse()
            {
                AccessToken = token,
                RefreshToken = refreshToken
            };
        }
    }
}
