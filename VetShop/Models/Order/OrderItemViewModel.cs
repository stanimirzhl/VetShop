namespace VetShop.Models.Order
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }

        public string ImageUrl { get; set; }
    }
}
