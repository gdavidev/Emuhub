using System.Text;

namespace Emuhub.Library.Transformation;

public class StringCase
{
    public static string ToKebabCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var sb = new StringBuilder();
        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (char.IsUpper(c))
            {
                if (i > 0 && input[i - 1] != '-')
                    sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            }
            else if (char.IsWhiteSpace(c) || c == '_' || c == '-')
            {
                sb.Append('-');
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString().Trim('-');
    }
}