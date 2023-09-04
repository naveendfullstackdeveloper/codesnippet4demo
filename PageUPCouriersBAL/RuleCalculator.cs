using PageUPCouriersDAL;

namespace PageUPCouriersBAL
{
    public class RuleCalculator
    {
        #region Public Methods

        /// <summary>
        /// This method takes order details and decides priority based on details.
        /// </summary>
        /// <param name="orderDetails">weight,height,width and depth details</param>
        /// <returns></returns>
        public static (PriorityOptions, double) GetPriorityByOrderDetails(OrderDetails orderDetails)
        {

            if (orderDetails.Weight <= 50 )
            {
                if (orderDetails.Weight <= 10)

                {
                    if (orderDetails.Height <= 105)
                    {
                        double volume = CalculateVolume(orderDetails);
                        return volume switch
                        {
                            < 1500 => (PriorityOptions.SmallParcel, volume),
                            > 1500 and < 2500 => (PriorityOptions.MediumParcel, volume),
                            _ => (PriorityOptions.LargeParcel, volume),
                        };
                    }

                }
                return (PriorityOptions.HeavyParcel, orderDetails.Weight);
            }
            return (PriorityOptions.Reject, orderDetails.Weight);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method calculate volume
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        private static double CalculateVolume(OrderDetails orderDetails)
        {
            return Math.Round((orderDetails.Height * orderDetails.Width * orderDetails.Depth));
        }

        #endregion
    }
}
