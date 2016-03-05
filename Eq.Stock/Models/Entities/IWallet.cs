using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eq.StockDomain.Models.Entities
{
    public interface IWallet
    {
        decimal Value { get; set; }
    }
}
