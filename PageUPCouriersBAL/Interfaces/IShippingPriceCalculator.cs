using PageUPCouriersDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageUPCouriersBAL.Interfaces
{
    public interface IShippingPriceCalculator
    {
        double Calculate(OrderDetails order);
    }
}
