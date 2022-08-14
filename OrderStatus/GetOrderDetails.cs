using Newtonsoft.Json;
using OrderStatus.Model;
using System.Net;

namespace OrderStatus
{
    public class GetOrderDetails
    {

        public List<shipmentDateDTO> getShipmentDate(string orderId)
        {
            var url = "https://orderstatusapi-dot-organization-project-311520.uc.r.appspot.com/api/getOrderStatus";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            List<shipmentDateDTO> obj_shipmentDateDTO = new List<shipmentDateDTO>();
            orderIDDTO obj = new orderIDDTO();
            obj.orderId = orderId;
            var data = JsonConvert.SerializeObject(obj);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                shipmentDateDTO res = Newtonsoft.Json.JsonConvert.DeserializeObject<shipmentDateDTO>(result);
                shipmentDateDTO obj1 = new shipmentDateDTO();
                DateTime shipmentDate = Convert.ToDateTime(res.message);
                obj1.message = "Your order " +orderId+ " will be shipped on " + shipmentDate.ToString("dddd, dd MMMM yyyy");
                obj_shipmentDateDTO.Add(obj1);
            }

            return obj_shipmentDateDTO;

        }

    }
}
