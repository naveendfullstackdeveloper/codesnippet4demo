using Microsoft.VisualBasic;
using PageUPCouriersBAL.Interfaces;
using PageUPCouriersDAL;

namespace PageUPCouriersBAL
{
    public class PriceCalculator
    {
        public class HeavyParcelCalculation : IShippingPriceCalculator
        {
            public double Calculate(OrderDetails order) => Math.Round(order.Weight * PageUPCouriersDAL.Constants.HeavyParcel, 2);
        }

        public class SmallParcelCalculation : IShippingPriceCalculator
        {
            public double Calculate(OrderDetails order) => Math.Round((order.Volume) * PageUPCouriersDAL.Constants.SmallParcel, 2);
        }

        public class MediumParcelCalculation : IShippingPriceCalculator
        {
            public double Calculate(OrderDetails order) => Math.Round((order.Volume) * PageUPCouriersDAL.Constants.MediumParcel, 2);
        }

        public class LargeParcelCalculation : IShippingPriceCalculator
        {
            public double Calculate(OrderDetails order) => Math.Round((order.Volume) * PageUPCouriersDAL.Constants.LargeParcel, 2);
        }
    }
}
