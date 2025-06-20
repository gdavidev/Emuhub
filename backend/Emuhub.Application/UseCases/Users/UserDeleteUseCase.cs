using System.Security.Claims;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories.Abstractions;

namespace Emuhub.Application.UseCases.Users;

public class UserDeleteUseCase(
    IUserRepository users)
{
    public async Task Execute(Guid targetId, ClaimsPrincipal sender)
    {
        var userId = Guid.Parse(sender.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        var userRole = sender.FindFirst(ClaimTypes.Role)?.Value!;

        if (userId != targetId && userRole != "Admin")
        {
            throw new ResourceNotFoundException(
                "User",
                ExceptionMessagesResource.USER_NOT_FOUND);
        }

        var userToBeDeleted = await users.GetById(userId);
        if (userToBeDeleted is null)
        {
            throw new ResourceNotFoundException(
                "User",
                ExceptionMessagesResource.USER_NOT_FOUND);
        }

        await users.Delete(userToBeDeleted);
    }
}