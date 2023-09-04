using PageUPCouriersBAL.Interfaces;
using PageUPCouriersDAL;

namespace PageUPCouriersBAL
{
    public class ShippingCalculator
    {
        readonly IShippingPriceCalculator _shippingCostStrategy;

        public ShippingCalculator(IShippingPriceCalculator shippingCostStrategy)
        {
            this._shippingCostStrategy = shippingCostStrategy;
        }

        public double CalculateCost(OrderDetails order) => _shippingCostStrategy.Calculate(order);
    }
}
