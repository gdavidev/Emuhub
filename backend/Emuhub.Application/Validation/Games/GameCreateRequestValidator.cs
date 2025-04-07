﻿using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Games
{
    public class GameCreateRequestValidator : AbstractValidator<GameCreateRequest>
    {
        public GameCreateRequestValidator(
            [FromServices] EmulatorRepository emulators,
            [FromServices] GameCategoryRepository categories)
        {
            RuleFor(request => request.Name)
                .NotNullOrEmpty();

            RuleFor(request => request.Description)
                .NotNullOrEmpty();

            RuleFor(request => request.EmulatorId)
                .DatabaseId()
                .MustAsync(async (id, _) => await emulators.Exists(id)).WithMessage(ExceptionMessagesResource.EMULATOR_NOT_FOUND);

            RuleFor(request => request.CategoryId)
                .DatabaseId() 
                .MustAsync(async (id, _) => await categories.Exists(id)).WithMessage(ExceptionMessagesResource.CATEGORY_NOT_FOUND);

            RuleFor(request => request.File)
                .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
                .SetValidator(new FileValidator([".zip"]));

            RuleFor(request => request.Image)
                .NotNull().WithMessage(ExceptionMessagesResource.FIELD_CANNOT_BE_NULL)
                .SetValidator(new FileValidator(FileValidator.IMAGE_EXTENSIONS));

        }
    }
}
