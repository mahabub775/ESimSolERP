using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

      /*  [HttpPost]
        public async Task<ActionResult> CreateOrder(Order oOrder)
        {
            Uri uri = new Uri("rabbitmq://localhost/order-queue");
           var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(oOrder);
            return Ok("Sucess");
        }*/

        [AllowAnonymous]
        [HttpPost("ChangeProductPrice")]
        public async Task<IActionResult> ChangeProductPrice()
        {

            try
            {
                Order Order = new Order(_bus);

              /*  OperationLog log = new OperationLog
                {
                    refObjID = 3,
                    operateBy = "atik",
                    moduleName = EnumModules.Jogajog,
                    operationDateTime = DateTime.Now,
                    userID = 789,
                    referenceText = "789",
                    operationType = EnumOperationType.Add



                };*/
                Order.Id = 1;
                Order.ProductName = "Pancil"; Order.Price = 152;
                Order RMqResponse = await Order.SendToStat(Order);
                var ExpectedObj = RMqResponse;
                //  var ExpectedObj = RMqResponse.dataList.Select(x => JsonConvert.DeserializeObject<User>(x.ToString())).ToList();

                return Ok(ExpectedObj);
            }
            catch (Exception e)
            {
                return StatusCode(100, "data not found" + e.Message);
            }
            return Ok();
        }

    }
}
