using System.ComponentModel.DataAnnotations;

namespace Emuhub.Application.Validation
{
    public class EmailValidator
    {
        public static bool IsEmailValid(string email)
        {
            if (email == null || email.Length == 0)
                return false;
            if (email.IndexOf(' ') > -1) 
                return false;
            return new EmailAddressAttribute().IsValid(email);            
        }

    }
}
