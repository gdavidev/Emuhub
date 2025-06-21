using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Mailing;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Random = Emuhub.Library.Generation.Random;

namespace Emuhub.Application.UseCases.Users;

public class UserForgotPasswordUseCase(
    UserForgotPasswordRequestValidator validator,
    IUserRepository users,
    IEmailService emailService,
    IConfiguration configuration)
{
    public async Task Execute(UserForgotPasswordRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var user = await users.GetByEmail(request.Email);
        
        if (user is not null)
        {
            var token = Random.GenerateBase64String(32);
            user.PasswordRetrievalToken = token;
            user.PasswordRetrievalTokenExpiryDate = DateTime.UtcNow.AddDays(1);
            await users.Update(user);
            
            var hostIp = configuration.GetValue<string>("HostIp");
            
            await emailService.SendEmailAsync(
                request.Email,
                "Account Password Reset",
                $$"""
                  You requested a password retrieval, create your new password at:
                  <br/>
                  <a href="http://{{hostIp}}:8080?token={{token}}">
                    Emuhub - Password Retrieval
                  </a>
                  <br/>
                  <br/>
                  This password retrieval link works for the next 24h.
                  If you haven't asked for a retrieval password link, contact support.
                  """);    
        }
        else
        {
            // else does nothing to not expose that the user exists,
            // but runs a timer to prevent timing attacks
            await Task.Delay(200);
        }
    }
}