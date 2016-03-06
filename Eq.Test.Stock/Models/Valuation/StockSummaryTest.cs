using Eq.StockDomain.Models.Valuation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.StockDomain.Models.Valuation
{
    [TestClass]
    public class StockSummaryTest
    {
        [TestMethod]
        public void CreateStockSummarySuccess()
        {
            //Arrange //Act
            var stockSummary = new StockSummary(1, 1, 1);

            //Assert
            Assert.AreEqual(1, stockSummary.TotalNumber);
            Assert.AreEqual(1, stockSummary.TotalStockValue);
            Assert.AreEqual(1, stockSummary.TotalStockWeight);
        }
    }
}
