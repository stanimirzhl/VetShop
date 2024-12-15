using VetShop.Models.Comment;

namespace VetShop.Models.Product
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel Product { get; set; }

        public CommentFormModel Comment { get; set; }

        public bool IsSavedByUser { get; set; }
    }
}
