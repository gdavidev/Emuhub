using Emuhub.Communication.Data.Emulators;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Application.Serialization
{
	public class EmulatorSerializer
	{
		public static Emulator ParseRequest(EmulatorCreateRequest request) =>
			new Emulator()
			{
				Id = 0,
				Name = request.Name,
				CompanyName = request.CompanyName,
				Abbreviation = request.Abbreviation,
				Console = request.Console,
			};

		public static Emulator ParseRequest(EmulatorUpdateRequest request) =>
			new Emulator()
			{
				Id = 0,
				Name = request.Name,
				CompanyName = request.CompanyName,
				Abbreviation = request.Abbreviation,
				Console = request.Console,
			};

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
