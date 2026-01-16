using System.Globalization;
using System.Windows.Controls;

namespace Projekt_WPF.Validators
{
    public class YearValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return ValidationResult.ValidResult;
            }

            return ValidationResult.ValidResult;
        }
    }
}