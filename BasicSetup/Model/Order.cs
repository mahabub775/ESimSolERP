using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }



       
    }
}
