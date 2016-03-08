using System.Globalization;
using System.Windows.Controls;

namespace Eq.UI.Validation
{
    /// <summary>
    /// Rule to check if provided value is different than
    /// </summary>
    public class NonZeroRule : ValidationRule
    {
        private readonly ValidationResult _wrongValue = new ValidationResult(false, "Wrong value has been provided");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var castedValue = value as string;
            if (castedValue == null)
            {
                return _wrongValue;
            }

            int parsedValue;
            if (!int.TryParse(castedValue, out parsedValue))
            {
                return _wrongValue;
            }

            return parsedValue == 0 ? new ValidationResult(false, "Value cannot be zero") : new ValidationResult(true, null);
        }
    }
}
