using Emuhub.Communication.Data.Emulators;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.Serialization;

public static class EmulatorSerializer
{
	public static EmulatorResponse ToResponse(Emulator emulator) =>
		new EmulatorResponse()
		{
			Id = emulator.Id,
			Name = emulator.Name,
			Abbreviation = emulator.Abbreviation,
		};
}