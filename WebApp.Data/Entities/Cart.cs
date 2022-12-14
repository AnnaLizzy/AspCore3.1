using System;


namespace WebApp.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { set; get; }
        public Product Product { set; get; }
        public DateTime DateCreated { set; get; }
        public Admin AppUser { set; get; }
    }
}
