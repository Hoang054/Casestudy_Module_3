namespace RPShop.Models.Entities
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public double Sum { get; set; }
        public Product Product { get; set; }

    }
}
