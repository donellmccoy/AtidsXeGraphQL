using System;
using System.Globalization;
using System.Windows.Controls;

namespace TheFund.AtidsXe.Modules.Common.ValidationRules
{
    public class SimpleDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out var time)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, "Invalid date");
        }
    }
}