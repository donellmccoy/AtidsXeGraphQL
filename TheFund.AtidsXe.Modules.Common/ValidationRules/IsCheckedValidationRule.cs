using System.Globalization;
using System.Windows.Controls;

namespace TheFund.AtidsXe.Modules.Common.ValidationRules
{
    public class IsCheckedValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value as bool? == true)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Option must be checked");
        }
    }
}
