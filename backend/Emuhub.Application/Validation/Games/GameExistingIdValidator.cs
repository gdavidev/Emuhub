using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games
{
    public class GameExistingIdValidator : AbstractValidator<long>
    {
        public GameExistingIdValidator(
            [FromServices] GameRepository games)
        {
            RuleFor(id => id)
                .DatabaseId()
                .MustAsync(async (id, _) => await games.Exists(id)).WithMessage(ExceptionMessagesResource.GAME_NOT_FOUND);
        }
    }
}
