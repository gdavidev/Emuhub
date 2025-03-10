using System.ComponentModel.DataAnnotations;
using Emuhub.Domain.Entities.Games;

namespace Emuhub.Communication.Data;

public record EmulatorDTO(
    [Required] long Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string CompanyName,
    [Required][StringLength(50)] string Abbreviation,
    [Required][StringLength(50)] string Console
);

public static class EmulatorExtensions
{
    public static EmulatorDTO AsDTO(this Emulator emulator)
    {
        return new EmulatorDTO(
            emulator.Id,
            emulator.Name,
            emulator.CompanyName,
            emulator.Abbreviation,
            emulator.Console
        );
    }
}
