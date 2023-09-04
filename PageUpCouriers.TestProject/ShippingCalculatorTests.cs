using PageUPCouriersBAL;
using PageUPCouriersDAL;
using static PageUPCouriersBAL.PriceCalculator;

namespace PageUpCouriers.TestProject
{
    [TestClass]
    public class ShippingCalculatorTests
    {
        [TestMethod]
        public void Price_When_Shipping_Via_SmallParcel_Volume_Is_0()
        {
            // Arrange
            var order = new OrderDetails();

            // Act
            var cost = new ShippingCalculator(new SmallParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(0.00d, cost);
        }

        [TestMethod]
        public void Price_When_Shipping_Via_SmallParcel_Volume_Is_978()
        {
            // Arrange
            var order = new OrderDetails(0.0, 22.8, 7.8, 5.5, 978);

            // Act
            var cost = new ShippingCalculator(new SmallParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(48.9d, cost);
        }

        [TestMethod]
        public void Price_When_Shipping_Via_HeavyParcel_Weight_Is_15()
        {
            // Arrange
            var order = new OrderDetails(15.0);

            // Act
            var cost = new ShippingCalculator(new HeavyParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(225.0d, cost);
        }

        [TestMethod]
        public void Price_When_Shipping_Via_HeavyParcel_Weight_Is_25()
        {
            // Arrange
            var order = new OrderDetails(25.0);

            // Act
            var cost = new ShippingCalculator(new HeavyParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(375.0d, cost);
        }

        [TestMethod]
        public void Price_When_Shipping_Via_MediumParcel_Volume_Is_1875()
        {
            // Arrange
            var order = new OrderDetails(0.0, 50.0, 7.5, 5.0, 1875);

            // Act
            var cost = new ShippingCalculator(new MediumParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(75.0d, cost);
        }
        [TestMethod]
        public void Price_When_Shipping_Via_LargeParcel_Volume_Is_3750()
        {
            // Arrange
            var order = new OrderDetails(0.0, 100.0, 7.5, 5.0, 3750);

            // Act
            var cost = new ShippingCalculator(new LargeParcelCalculation()).CalculateCost(order);

            Assert.AreEqual(112.5d, cost);
        }


    }
}