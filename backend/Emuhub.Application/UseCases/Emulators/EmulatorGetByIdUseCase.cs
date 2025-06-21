using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Emulators;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories.Abstractions;

namespace Emuhub.Application.UseCases.Emulators;

public class EmulatorGetByIdUseCase(IEmulatorRepository emulators)
{
    public async Task<EmulatorResponse> Execute(long emulatorId)
    {
        if (emulatorId <= 0)
        {
            throw new ValidationErrorException(new ValidationErrorItem(
                "EmulatorId",
                "EmulatorId must be greater than zero"));
        }

        var emulator = (await emulators.Get(emulatorId))!;

        return EmulatorSerializer.ToResponse(emulator);
    }
}