using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Domain.Entities.Users;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Authentication;
using Emuhub.Infrastructure.Services.Storage;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Emuhub.Application.UseCases.Users;

public class UserUpdateUseCase(
    IUserRepository users,
    UserUpdateRequestValidator validator,
    IFileStorageService storageService)
{
    public async Task Execute(UserUpdateRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
        var sanitizedRequest = Sanitized(request);
        
        var user = await users.GetById(request.UserId);
        if (user is null)
        {
            throw new ResourceNotFoundException(
                "User",
                ExceptionMessagesResource.USER_NOT_FOUND);
        }
        
        if (sanitizedRequest.UserName is not null)
            user.Name = sanitizedRequest.UserName;
        if (sanitizedRequest.Email is not null)
            user.Email = sanitizedRequest.Email;
        if (sanitizedRequest.Password is not null)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, sanitizedRequest.Password);
            user.PasswordHash = hashedPassword;
        }
        if (sanitizedRequest.ProfileImage is not null)
        {
            var image = sanitizedRequest.ProfileImage;
            var profileFileName = $"profile{Path.GetExtension(image.FileName)}";
            await storageService.UploadAsync(
                "users",
                image.OpenReadStream(),
                $"{request.UserId}/{profileFileName}",
                image.ContentType
            );
        }

        await users.Update(user);
    }
    
    private static UserUpdateRequest Sanitized(UserUpdateRequest request)
    {
        request.Email = request.Email?.Trim().ToLower();
        return request;
    }  
}