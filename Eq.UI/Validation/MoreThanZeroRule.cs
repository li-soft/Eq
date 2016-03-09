using System.Globalization;
using System.Windows.Controls;

namespace Eq.UI.Validation
{
    /// <summary>
    /// Rule to check if provided value is positive
    /// </summary>
    public class MoreThanZeroRule : ValidationRule
    {
        private readonly ValidationResult _wrongValue = new ValidationResult(false, "Wrong value has been provided");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var castedValue = value as string;
            if (castedValue == null)
            {
                return _wrongValue;
            }

            decimal parsedValue;
            if (!decimal.TryParse(castedValue, NumberStyles.Number, cultureInfo, out parsedValue))
            {
                return _wrongValue;
            }

            return parsedValue < 0.01m ? new ValidationResult(false, "Value need to be more than 0.01") : new ValidationResult(true, null);
        }
    }
}
