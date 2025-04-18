using Emuhub.Communication.Data;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games
{
    public class GameExistingIdValidator : AbstractValidator<EntityIdRequest>
    {
        public GameExistingIdValidator(
            [FromServices] IGameRepository games)
        {
            RuleFor(request => request.Id)
                .DatabaseIdentity()
                .MustAsync(async (id, _) => await games.Exists(id)).WithMessage(ExceptionMessagesResource.GAME_NOT_FOUND);
        }
    }
}
