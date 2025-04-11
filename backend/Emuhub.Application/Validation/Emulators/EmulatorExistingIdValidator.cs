using Emuhub.Communication.Data;
using Emuhub.Exceptions;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.Application.Validation.Emulators
{
    public class EmulatorExistingIdValidator : AbstractValidator<EntityIdRequest>
    {
        public EmulatorExistingIdValidator(
            [FromServices] IEmulatorRepository Emulators)
        {
            RuleFor(request => request.Id)
                .DatabaseIdentity()
                .MustAsync(async (id, _) => await Emulators.Exists(id)).WithMessage(ExceptionMessagesResource.EMULATOR_NOT_FOUND);
        }
    }
}
