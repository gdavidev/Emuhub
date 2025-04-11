using Emuhub.Communication.Data.Emulators;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.Serialization
{
	public class EmulatorSerializer
	{
		public static EmulatorResponse ToResponse(Emulator emulator) =>
			new EmulatorResponse()
			{
				Id = emulator.Id,
				Name = emulator.Name,
				CompanyName = emulator.CompanyName,
				Abbreviation = emulator.Abbreviation,
				Console = emulator.Console,
			};
	}
}
