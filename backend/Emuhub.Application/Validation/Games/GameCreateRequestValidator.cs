using Emuhub.Application.Validation.ValidatorExtensions;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games;

public class GameCreateRequestValidator : AbstractValidator<GameCreateRequest>
{
    public GameCreateRequestValidator(
        [FromServices] IEmulatorRepository emulators,
        [FromServices] IGameCategoryRepository categories)
    {
        RuleFor(request => request.Name)
            .NotNullOrEmpty();

        RuleFor(request => request.Description)
            .NotNullOrEmpty();

        RuleFor(request => request.EmulatorId)
            .Cascade(CascadeMode.Stop)
            .DatabaseIdentity()
            .MustAsync(async (id, _) => await emulators.Exists(id))
                .WithMessage(ExceptionMessagesResource.EMULATOR_NOT_FOUND);

        RuleFor(request => request.CategoryId)
            .Cascade(CascadeMode.Stop)
            .DatabaseIdentity() 
            .MustAsync(async (id, _) => await categories.Exists(id))
                .WithMessage(ExceptionMessagesResource.CATEGORY_NOT_FOUND);

        RuleFor(request => request.File)
            .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
            .FileOfType([".zip"]);

        RuleFor(request => request.Image)
            .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
            .FileOfType([".png", ".jpg", ".jpeg", ".gif"]);
    }
}