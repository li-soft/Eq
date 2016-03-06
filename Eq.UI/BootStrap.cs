using System;
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

        /// <summary>
        /// Initialize Windsor container and install all Fund Domain dependencies
        /// </summary>
        private static void InitializeContainer()
        {
            IoC.Install(new FundDomainInstaller());
        }
    }
}
