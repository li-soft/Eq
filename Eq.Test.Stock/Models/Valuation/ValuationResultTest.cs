using System.Collections.Generic;
using System.Linq;
using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Models.Valuation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.StockDomain.Models.Valuation
{
    [TestClass]
    public class ValuationResultTest
    {
        [TestMethod]
        public void PrepareValuationResultEntitySuccess()
        {
            //Arrange //Act
            var ss = new StockSummary(1, 1, 1);
            var vr = new ValuationResult(new Dictionary<StockType, IStockSummary> {{StockType.Bond, ss}});

            //Assert
            Assert.AreEqual(1, vr.StockSummaryPerStockType.Values.First().TotalStockWeight);
            Assert.AreEqual(1, vr.StockSummaryPerStockType.Values.First().TotalNumber);
            Assert.AreEqual(1, vr.StockSummaryPerStockType.Values.First().TotalStockValue);
            Assert.AreEqual(StockType.Bond, vr.StockSummaryPerStockType.Keys.First());
        }
    }
}
