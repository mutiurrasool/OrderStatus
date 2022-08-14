using Microsoft.AspNetCore.Mvc;
using OrderStatus.Model;

namespace OrderStatus.Controllers
{
    public class OrderController : Controller
    {


        [HttpPost]
        [Route("GetOrder")]
        public List<shipmentDateDTO> getOrder(string orderId)
        {
            List<shipmentDateDTO> orders = new List<shipmentDateDTO>();
            GetOrderDetails getOrderDetails = new GetOrderDetails();
            orders = getOrderDetails.getShipmentDate(orderId);

            return orders;
        }

    }
}
