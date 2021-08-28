using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
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
        readonly IBusControl _bus;

        public OrderController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order oOrder)
        {
            Uri uri = new Uri("rabbitmq://localhost/order-queue");
           var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(oOrder);
            return Ok("Sucess");
        }
    }
}
