using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        private readonly IBus _bus;
        public Order(IBus bus)
        {
            _bus = bus;

        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }



        public async Task<Order> SendToStat(Order operationLog)
        {
            try
            {
                //Uri uri = new Uri("rabbitmq://localhost/order-queue");
                Uri uri = new Uri("rabbitmq://localhost/PriceChange-queue");
                var client = _bus.CreateRequestClient<Order>(uri);
                var response = await client.GetResponse<Order>(operationLog);
                if (response != null)
                {
                    return await Task.FromResult<Order>(response.Message);
                }
                else
                {
                    return await Task.FromResult<Order>(new Order(_bus));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
