using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games
{
    public class GameUpdateRequestValidator : AbstractValidator<GameUpdateRequest>
    {
        public GameUpdateRequestValidator(
            [FromServices] GameExistingIdValidator idValidator,
            [FromServices] IEmulatorRepository emulators,
            [FromServices] IGameCategoryRepository categories)
        {
            RuleFor(request => new GameExistingIdRequest() { Id = request.Id })
                .SetValidator(idValidator);

            RuleFor(request => request.Name)
                .NotNullOrEmpty();

            RuleFor(request => request.Description)
                .NotNullOrEmpty();

            RuleFor(request => request.EmulatorId)
                .DatabaseIdentity()
                .MustAsync(async (id, _) => await emulators.Exists(id)).WithMessage(ExceptionMessagesResource.EMULATOR_NOT_FOUND);

            RuleFor(request => request.CategoryId)
                .DatabaseIdentity()
                .MustAsync(async (id, _) => await categories.Exists(id)).WithMessage(ExceptionMessagesResource.CATEGORY_NOT_FOUND);

            When(request => request.File != null, () =>
            {
                RuleFor(request => request.File!)
                    .FileOfType(FileType.ARCHIVE);
            });

            When(request => request.Image != null, () =>
            {
                RuleFor(request => request.Image!)
                    .FileOfType(FileType.IMAGE);
            });
        }
    }
}
