using Eq.StockDomain.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Eq.Test.StockDomain.Models.Entities
{
    [TestClass]
    public class BondTest
    {
        [TestMethod]
        public void GetPriceAndQuantitySuccess()
        {
            //Arrange
            var bond = new Bond(12.9m, 100);

            //Act
            var price = bond.Price;
            var quantity = bond.Quantity;

            //Assert
            Assert.AreEqual(12.9m, price);
            Assert.AreEqual(0100, quantity);
        }

        [TestMethod]
        public void AssignIdToStockSuccess()
        {
            //Arrange
            var bond = new Bond(12.9m, 100);

            //Act
            bond.AssignId(12);

            //Assert
            Assert.AreEqual(12, bond.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenIdIsLessThan1()
        {
            //Arrange //Act //Assert
            new Bond(12.9m, 100).AssignId(-3);
        }

        [TestMethod]
        public void StockIsValidSuccesStockIsValidWhenIdIsAssigned()
        {
            //Arrange
            var bond = new Bond(12.9m, 100);

            //Act
            bond.AssignId(12);

            //Assert
            Assert.IsTrue(bond.IsValid());
        }

        [TestMethod]
        public void StockIsNotValidSuccesStockIsNotValidWhenIdIsNotAssigned()
        {
            //Arrange
            var bond = new Bond(12.9m, 100);

            //Act
            
            //Assert
            Assert.IsFalse(bond.IsValid());
        }

        [TestMethod]
        public void StockToStringOverrideMethodTestSuccess()
        {
            //Arrange
            StockBase bond = new Bond(12.9m, 100);

            //Act
            bond.AssignId(12);

            //Assert
            Assert.AreEqual("Bond12", bond.ToString());
        }
    }
}
