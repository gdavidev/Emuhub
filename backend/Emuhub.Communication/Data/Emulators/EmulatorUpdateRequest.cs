namespace Emuhub.Communication.Data.Emulators
{
	public class EmulatorUpdateRequest
	{
		public required long Id { get; set; }
		public required string Name { get; set; }
		public required string CompanyName { get; set; }
		public required string Abbreviation { get; set; }
		public required string Console { get; set; }
	}
}
