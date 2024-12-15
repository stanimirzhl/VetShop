using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;
using static VetShop.Infrastructure.Constants.DataConstants.CommentConstants;

namespace VetShop.Models.Comment
{
    public class CommentFormModel
    {
        [Required(ErrorMessage = CommentTitleRequiredMessage)]
        [StringLength(MaxCommentTitle, MinimumLength = MinCommentTitle, ErrorMessage = CommentTitleLengthMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = CommentDescriptionRequiredMessage)]
        [StringLength(MaxCommentDescription, MinimumLength = MinCommentDescription, ErrorMessage = CommentDescriptionLengthMessage)]
        public string Description { get; set; }
    }
}
