using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public string Name { get; set; }
    }
}
