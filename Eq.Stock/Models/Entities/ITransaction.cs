using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eq.StockDomain.Models.Entities
{
    public interface ITransaction
    {
        IEnumerable<IStock> Stocks { get; set; }
        decimal Cost { get; set; }
        decimal Value { get; set; }
    }
}
