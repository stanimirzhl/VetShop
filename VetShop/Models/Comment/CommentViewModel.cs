namespace VetShop.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? AuthorName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
