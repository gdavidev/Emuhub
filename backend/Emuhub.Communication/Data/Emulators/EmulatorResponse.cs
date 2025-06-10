using System.ComponentModel.DataAnnotations;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data.Emulators;

public class EmulatorResponse {
	public required long Id { get; set; }
	public required string Name { get; set; }
	public required string CompanyName { get; set; }
	public required string Abbreviation { get; set; }
	public required string Console { get; set; }
}