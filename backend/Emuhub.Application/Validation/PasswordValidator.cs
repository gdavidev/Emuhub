using System.Text.RegularExpressions;

namespace Emuhub.Application.Validation
{
    public partial class PasswordValidator
    {
        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")]
        private static partial Regex PasswordPattern();

        public static bool IsPasswordValid(string password)
        {
            if (password == null || password.Length < 8)
                return false;
            if (!PasswordPattern().IsMatch(password))
                return false;
            return true;
        }        
    }
}
