using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderStatus.Model
{
    public class orderIDDTO
    {
        [JsonProperty("orderId")]
        public string orderId { get; set; }
    }
    public class shipmentDateDTO
    {
        public string message { get; set; }
    }
}
