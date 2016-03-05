using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eq.StockDomain.Models.Entities
{
    public class Bond : StockBase
    {
        public Bond(decimal price, int quantity) : base(price, quantity)
        {}

        public override decimal Fee
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
