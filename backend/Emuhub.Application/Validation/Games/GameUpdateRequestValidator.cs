using Emuhub.Application.Validation.ValidatorExtensions;
using Emuhub.Communication.Data;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using Emuhub.Infrastructure.Repositories.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games;

public class GameUpdateRequestValidator : AbstractValidator<GameUpdateRequest>
{
    public GameUpdateRequestValidator(
        [FromServices] GameExistingIdValidator idValidator,
        [FromServices] IEmulatorRepository emulators,
        [FromServices] IGameCategoryRepository categories) 
    {
        RuleFor(request => request.Id)
            .MustAsync(async (id, cancellationToken) =>
                {
                    var result = await idValidator.ValidateAsync(
                        new EntityIdRequest() { Id = id },
                        cancellationToken);
                    return result.IsValid;
                })
            .WithMessage(ExceptionMessagesResource.GAME_NOT_FOUND);
        
        RuleFor(request => request.Name!)
            .NotEmpty();

        RuleFor(request => request.Description!)
            .NotEmpty();

        RuleFor(request => (long)request.EmulatorId!)
            .Cascade(CascadeMode.Stop)
            .DatabaseIdentity()
            .MustAsync(async (id, _) => await emulators.Exists(id))
            .WithMessage(ExceptionMessagesResource.EMULATOR_NOT_FOUND);
    
        RuleFor(request => (long)request.CategoryId!)
            .Cascade(CascadeMode.Stop)
            .DatabaseIdentity() 
            .MustAsync(async (id, _) => await categories.Exists(id))
            .WithMessage(ExceptionMessagesResource.CATEGORY_NOT_FOUND);

        When(request => request.File is not null, () =>
        {
            RuleFor(request => request.File!)
                .FileOfType([".zip"]);
        });

        When(request => request.Image is not null, () =>
        {
            RuleFor(request => request.Image!)
                .FileOfType([".png", ".jpg", ".jpeg", ".gif"]);
        });
    }
}