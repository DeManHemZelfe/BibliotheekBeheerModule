using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BibliotheekBeheerModule.ValidationRules
{
    public partial class InputLenghtValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                if (value.ToString().Length > 1)
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "Must be atleast 2 characters long");
        }
    }
}
