using System.Security.Cryptography;
using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Infrastructure.Services.Mailing;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users;

public class UserForgotPasswordUseCase(
    UserForgotPasswordRequestValidator validator,
    IEmailService emailService)
{
    public async Task Execute(UserForgotPasswordRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
        
        await emailService.SendEmailAsync(
            request.Email,
            "Account Password Reset",
            $$"""
              
              """);
    }
}