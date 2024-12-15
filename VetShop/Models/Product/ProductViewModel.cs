using VetShop.Core;
using VetShop.Models.Comment;

namespace VetShop.Models.Product
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }

        public List<int> SelectedBrandIds { get; set; } = new List<int>();

        public PagingModel<CommentViewModel>? Comments { get; set; }
    }
}
