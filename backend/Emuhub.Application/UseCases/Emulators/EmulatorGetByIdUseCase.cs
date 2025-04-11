using Emuhub.Application.Serialization;
using Emuhub.Application.Validation.Emulators;
using Emuhub.Communication.Data;
using Emuhub.Communication.Data.Emulators;
using Emuhub.Infrastructure.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Emuhub.Application.UseCases.Emulators
{
    public class EmulatorGetByIdUseCase(IEmulatorRepository emulators, EmulatorExistingIdValidator validator)
    {
        public async Task<EmulatorResponse> Execute(EntityIdRequest request)
        {
            await validator.ValidateAndThrowAsync(request);

            var emulator = (await emulators.Get(request.Id))!;

            return EmulatorSerializer.ToResponse(emulator);
        }
    }
}
