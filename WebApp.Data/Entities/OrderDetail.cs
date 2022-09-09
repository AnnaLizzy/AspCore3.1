using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.Entities
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { set; get; }
        public Product Product { get; set; }
    }
}
