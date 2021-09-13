using MassTransit;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSetup
{
    public class OrderConsumer : IConsumer<Order>
    {
        
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data =(Order)context.Message;
            data.Price = 350;
            await context.RespondAsync(data);
        }

       /*Task IConsumer<Order>.Consume(ConsumeContext<Order> context)
        {
            // throw new NotImplementedException();

            Order data = (Order)context.Message;
            data.Price = 350;
            return data;
        }*/
    }
}
