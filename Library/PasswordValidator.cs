using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(string validateObject)
        {
            if (string.IsNullOrEmpty(validateObject))
                return false;

            if (validateObject.Length < 8 || validateObject.Length > 20)
                return false;

            bool hasUpperCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in validateObject)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if ("!@#$%^&*-_".Contains(c))
                    hasSpecialChar = true;
            }

            return hasUpperCase && hasDigit && hasSpecialChar;
        }
    }
}
