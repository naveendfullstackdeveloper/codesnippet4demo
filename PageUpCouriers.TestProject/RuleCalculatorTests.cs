using PageUPCouriersBAL;
using PageUPCouriersDAL;

namespace PageUpCouriers.TestProject
{
    [TestClass]
    public class RuleCalculatorTests
    {

        [TestMethod]
        public void Decide_Priority_For_LargeParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 100.0, 7.5, 5.0, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(PriorityOptions.LargeParcel.ToString(), priority.Item1);
        }


        [TestMethod]
        public void Decide_Priority_For_SmallParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 7.0, 5.5, 5.0, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(PriorityOptions.SmallParcel.ToString(), priority.Item1);
        }


        [TestMethod]
        public void Decide_Priority_For_MediumParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 50.0, 7.5, 5.0, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(PriorityOptions.MediumParcel.ToString(), priority.Item1);
        }

        [TestMethod]
        public void verify_Volume_For_MediumParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 50.0, 7.5, 5.0, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(1875d, priority.Item2);
        }

        [TestMethod]
        public void verify_Volume_For_SmallParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 22.8, 7.8, 5.5, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(978d, priority.Item2);
        }

        [TestMethod]
        public void verify_Volume_For_LargeParcel()
        {
            // Arrange
            var order = new OrderDetails(0.0, 100.0, 7.5, 5.0, 0);

            // Act
            var priority = RuleCalculator.GetPriorityByOrderDetails(order);

            Assert.AreEqual(3750d, priority.Item2);
        }

    }
}
