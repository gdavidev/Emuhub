using Emuhub.Application.Validation.Users;
using Emuhub.Communication.Data.Users;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;

namespace Emuhub.Application.UseCases.Users;

public class UserResetPasswordUseCase(
    IUserRepository repository,
    UserResetPasswordRequestValidator validator)
{
    public async Task Execute(UserResetPasswordRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
    }
}