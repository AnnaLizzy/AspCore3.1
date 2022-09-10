using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.Enum;

namespace WebApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }

        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { get; set; }
    }
}
