using Emuhub.Application.Serialization;
using Emuhub.Communication.Data.Emulators;
using Emuhub.Infrastructure.Repositories.Abstractions;

namespace Emuhub.Application.UseCases.Emulators;

public class EmulatorGetUseCase(IEmulatorRepository emulators)
{
    public async Task<List<EmulatorResponse>> Execute()
    {
        var emulatorList = await emulators.GetAll();
        var result = emulatorList.Select(EmulatorSerializer.ToResponse).ToList();

        return result;
    }
}