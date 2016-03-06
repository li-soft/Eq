using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Eq.StockDomain.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eq.Test.StockDomain.Config
{
    [TestClass]
    public class FundDomainInstallerTest
    {
        [TestMethod]
        public void InstallationTestSuccess()
        {
            //Arrange
            var containerMock = new Mock<IWindsorContainer>();
            containerMock.Setup(x => x.Register(It.IsAny<IRegistration>()));
            var configStoreMock = new Mock<IConfigurationStore>();
            var installer = new FundDomainInstaller();

            //Act
            installer.Install(containerMock.Object, configStoreMock.Object);

            //Assert
            containerMock.Verify(x => x.Register(It.IsAny<IRegistration>()), Times.Exactly(5));
        }
    }
}
