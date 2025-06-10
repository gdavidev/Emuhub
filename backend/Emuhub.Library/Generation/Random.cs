using System.Security.Cryptography;

namespace Emuhub.Library.Generation;

public class Random
{
    private static string GenerateBase64String(int lenght)
    {
        using var rng = RandomNumberGenerator.Create();
        
        var randomNumber = new byte[lenght];
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}