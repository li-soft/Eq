using System;
using Eq.Core;
using Eq.StockDomain;
using Eq.StockDomain.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.StockDomain
{
    public abstract class UnitTestBase
    {
        protected static void TryRegisterWallet(IWallet wallet)
        {
            wallet = wallet ?? new Wallet();
            try
            {
                IoC.RegisterSingleInstance(wallet);
            }
            catch (Exception)
            { }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            IoC.Release((Wallet)IoC.Resolve<IWallet>());
        }
    }
}
