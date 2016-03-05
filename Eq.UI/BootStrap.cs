using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Eq.StockDomain.Config;
using Eq.Core;

namespace Eq.UI
{
    public class BootStrap
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            InitializeContainer();

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        private static void InitializeContainer()
        {
            IoC.Container = new WindsorContainer();
            IoC.Container.Install(new FundDomainInstaller());
        }
    }
}
