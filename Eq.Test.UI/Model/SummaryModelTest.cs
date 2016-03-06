using Eq.StockDomain.Models.Valuation;
using Eq.UI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.UI.Model
{
    [TestClass]
    public class SummaryModelTest
    {
        [TestMethod]
        public void MapFromStockSummarySuccess()
        {
            //Arrange //Act
            var model = SummaryModel.MapFrom(new StockSummary(1, 1, 1), "HH");

            //Assert
            Assert.AreEqual("HH", model.TypeName);
            Assert.AreEqual(1, model.TotalNumber);
            Assert.AreEqual(1, model.TotalMarketValue);
            Assert.AreEqual(1, model.TotalStockWeight);
        }
    }
}
