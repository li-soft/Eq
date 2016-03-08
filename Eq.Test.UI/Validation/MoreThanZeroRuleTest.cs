using System.Globalization;
using System.Windows.Controls;
using Eq.UI.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.UI.Validation
{
    [TestClass]
    public class MoreThanZeroRuleTest
    {
        private readonly ValidationResult _wrongValue = new ValidationResult(false, "Wrong value has been provided");

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsNotString()
        {
            //Arrange
            var validator = new MoreThanZeroRule();

            //Act
            var result = validator.Validate(new object(), CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(_wrongValue, result);
        }

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsStringAndCannotParseToDecimal()
        {
            //Arrange
            var validator = new MoreThanZeroRule();

            //Act
            var result = validator.Validate("NotDecimal", CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(_wrongValue, result);
        }

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsNegativeDecimalValue()
        {
            //Arrange
            var validator = new MoreThanZeroRule();

            //Act
            var result = validator.Validate("-3", CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(new ValidationResult(false, "Value has to be positive"), result); 
        }

        [TestMethod]
        public void GetValidWhenProvidedValueIsDecimalValue()
        {
            //Arrange
            var validator = new MoreThanZeroRule();
            var correctDecimalAsString = $"10{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}34";

            //Act
            var result = validator.Validate(correctDecimalAsString, CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(new ValidationResult(true, null), result);
        }
    }
}
