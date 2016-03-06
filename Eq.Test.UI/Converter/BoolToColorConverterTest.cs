using System.Windows.Media;
using Eq.UI.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.UI.Converter
{
    [TestClass]
    public class BoolToColorConverterTest
    {
        [TestMethod]
        public void ConvertTrueValueToRedColorSuccess()
        {
            //Arrange //Act
            var color = ((SolidColorBrush)new BoolToColorConverter().Convert(true, null, null, null)).Color;

            //Assert
            Assert.AreEqual(Colors.Red, color);
        }

        [TestMethod]
        public void ConvertFalseValueToTransparentColorSuccess()
        {
            //Arrange //Act
            var color = ((SolidColorBrush)new BoolToColorConverter().Convert(false, null, null, null)).Color;

            //Assert
            Assert.AreEqual(Colors.Transparent, color);
        }

        [TestMethod]
        public void ReturnFalseWhenValueIsNotABooleanType()
        {
            //Arrange //Act
            var bFalse = (bool)new BoolToColorConverter().Convert(new object(), null, null, null);

            //Assert
            Assert.IsFalse(bFalse);
        }

        [TestMethod]
        public void ConvertRedColorTpTrueValueSuccess()
        {
            //Arrange //Act
            var bTrue = (bool)new BoolToColorConverter().ConvertBack(new SolidColorBrush(Colors.Red), null, null, null);

            //Assert
            Assert.IsTrue(bTrue);
        }

        [TestMethod]
        public void ConvertOtherThanRedColorToFalselueSuccess()
        {
            //Arrange //Act
            var bFalse = (bool)new BoolToColorConverter().ConvertBack(new SolidColorBrush(Colors.Magenta), null, null, null);

            //Assert
            Assert.IsFalse(bFalse);
        }
    }
}
