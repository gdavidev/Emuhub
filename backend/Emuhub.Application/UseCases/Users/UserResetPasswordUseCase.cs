using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Domain.Entities.Users;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Emuhub.Application.UseCases.Users;

public class UserResetPasswordUseCase(
    IUserRepository users,
    UserResetPasswordRequestValidator validator)
{
    public async Task Execute(UserResetPasswordRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var user = await users.GetByPasswordResetToken(request.RetrievalToken);

        if (user is null)
            throw new ResourceNotFoundException(
                "User",
                ExceptionMessagesResource.USER_NOT_FOUND);

        if (user.PasswordRetrievalTokenExpiryDate < DateTime.UtcNow)
            throw new ValidationErrorException(new ValidationErrorItem(
                "RetrievalToken",
                ExceptionMessagesResource.TOKEN_INVALID));
        
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, request.NewPassword);
        
        user.PasswordHash = hashedPassword;
        user.RefreshTokenExpiryDate = null;
        user.RefreshToken = null;
        
        await users.Update(user);
    }
}