using System;
using System.Globalization;
using System.Windows.Controls;
using Eq.UI.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.UI.Validation
{
    [TestClass]
    public class NonZeroRuleTest
    {
        private readonly ValidationResult _wrongValue = new ValidationResult(false, "Wrong value has been provided");

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsNotString()
        {
            //Arrange
            var validator = new NonZeroRule();

            //Act
            var result = validator.Validate(new object(), CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(_wrongValue, result);
        }

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsStringAndCannotParseToInt()
        {
            //Arrange
            var validator = new NonZeroRule();

            //Act
            var result = validator.Validate("NotInt", CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(_wrongValue, result);
        }

        [TestMethod]
        public void GetNonValidWhenProvidedValueIsZero()
        {
            //Arrange
            var validator = new NonZeroRule();

            //Act
            var result = validator.Validate("0", CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(new ValidationResult(false, "Value cannot be zero"), result);
        }

        [TestMethod]
        public void GetValidWhenProvidedValueIsNonZeroIntValueValue()
        {
            //Arrange
            var validator = new NonZeroRule();

            //Act
            var result = validator.Validate("-2", CultureInfo.CurrentCulture);

            //Assert
            Assert.AreEqual(new ValidationResult(true, null), result);
        }
    }
}
