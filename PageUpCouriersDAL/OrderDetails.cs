using System.ComponentModel;

namespace PageUPCouriersDAL
{
    public class OrderDetails
    {

        public OrderDetails(double weight = 0d, double height = 0d, double width = 0d, double depth = 0d, double volume = 0d)
        {
            Weight = weight;
            Height = height;
            Width = width;
            Depth = depth;
            Volume = volume;
        }


        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Volume { get; set; }
    }

    public enum PriorityOptions
    {
        [Description("Reject")]
        Reject = 1,

        [Description("Heavy Parcel")]
        HeavyParcel = 2,

        [Description("Small Parcel")]
        SmallParcel = 3,

        [Description("Medium Parcel")]
        MediumParcel = 4,

        [Description("Large Parcel")]
        LargeParcel = 5

    }

    public enum StatusCode
    {
        Reject = 1,
        Heavy = 2,
        Small = 3,
        Medium = 4,
        Large = 5,
    }

    public static class Constants
    {
        public const double Reject = 0;
        public const double HeavyParcel = 15;
        public const double SmallParcel = 0.05;
        public const double MediumParcel = 0.04;
        public const double LargeParcel = 0.03;
    }
}