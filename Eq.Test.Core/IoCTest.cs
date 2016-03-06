using Eq.Core;
using Eq.Test.Core.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.Core
{
    [TestClass]
    public class IoCTest
    {
        private readonly MockObj _mo = new MockObj {Value = 1};

        [TestMethod]
        public void RegisterAndResolveTypeSuccess()
        {
            //Arrange 
            IoC.RegisterSingleInstance<IMockInt>(_mo);

            //Act
            var instance = IoC.Resolve<IMockInt>();

            //Assert
            Assert.AreEqual(1, instance.Value);
        }
    }
}
