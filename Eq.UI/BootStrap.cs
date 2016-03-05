using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Eq.StockDomain.Config;

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
            var container = new WindsorContainer();
            container.Install(new FundDomainInstaller());
        }
    }
}
