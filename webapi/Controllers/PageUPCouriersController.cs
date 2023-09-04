using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using PageUpApi.InputDto;
using PageUPCouriersBAL;
using PageUPCouriersBAL.Interfaces;
using PageUPCouriersDAL;

namespace PageUpApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PageUPCouriersController : Controller
    {
        public PageUPCouriersController()

        {
        }

        [ProducesResponseType(typeof(PriceResult), 200)]
        [HttpPost(Name = "calculateprice")]
        public IActionResult CaluclatePrice([FromBody] OrderInputDetails orderInputDetails)
        {
            OrderDetails orderDetails = new(orderInputDetails.Weight, orderInputDetails.Height, orderInputDetails.Width, orderInputDetails.Depth);
            var priority = RuleCalculator.GetPriorityByOrderDetails(orderDetails);
            var result = new PriceResult();

            var tupleResult = new Result
            {
                rule = priority.Item1,
                volumeorweight = priority.Item2
            };

          // Here we can create an interface and methods to implement below functionality but the reason
          // using with factory pattern was to show the factory pattern implementation.
          // Let me know incase if you want me to implement different way with interfaces.

            if (tupleResult.rule.ToString() != PriorityOptions.Reject.GetDisplayName())
            {
                string? objectToInstantiate = "PageUPCouriersBAL.PriceCalculator+" + tupleResult.rule.ToString() + "Calculation, PageUPCouriersBAL";

                var factory = Activator.CreateInstance(Type.GetType(objectToInstantiate)!) as IShippingPriceCalculator;

                double price = factory!.Calculate(new
                                        OrderDetails(orderDetails.Weight, orderDetails.Height, orderDetails.Width, orderDetails.Depth, tupleResult.volumeorweight));

                result = new PriceResult()
                { StatusCode = Convert.ToInt32(tupleResult.rule), CustomMessage = Common.GetEnumDescription(tupleResult.rule) + " price :" + price };

            }
            else
            {
                result = new PriceResult()
                { StatusCode = Convert.ToInt32(tupleResult.rule), CustomMessage = "Apologies, If the parcel weight exceed 50Kg then sorry we could not process the order" };
            }
            return Ok(result);

        }

        struct Result
        {
            public PriorityOptions rule;
            public double volumeorweight;
        }

        public class PriceResult
        {
            public int StatusCode { get; set; }
            public string? CustomMessage { get; set; }

        }



    }
}
