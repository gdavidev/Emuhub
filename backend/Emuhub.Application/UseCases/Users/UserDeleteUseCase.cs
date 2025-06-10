using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users;

public class UserDeleteUseCase(
    IUserRepository users,
    UserDeleteRequestValidator validator)
{
    public async Task Execute(UserDeleteRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var userToBeDeleted = await users.GetById(request.UserId);
        if (userToBeDeleted is null)
        {
            throw new ResourceNotFoundException(
                "User",
                ExceptionMessagesResource.USER_NOT_FOUND);
        }

        await users.Delete(userToBeDeleted);
    }
}