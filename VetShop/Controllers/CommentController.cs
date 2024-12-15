using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using VetShop.Core;
using VetShop.Core.Interfaces;
using VetShop.Models.Comment;

namespace VetShop.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private ILogger<CommentController> logger;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            this.commentService = commentService;
            this.logger = logger;
        }

        public async Task<IActionResult> All(int pageIndex = 1, int pageSize = 10)
        {
            var query = await commentService.GetAllPagedCommentsAsync(pageIndex, pageSize);

            var mappedQuery = query.Map(x => new CommentViewModel
            {
               AuthorName = x.AuthorName,
               CreatedOn = x.CreatedOn,
               Description = x.Description,
               Id = x.Id,
               Title = x.Title,
            });

            return View(mappedQuery);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int commentId)
        {
            try
            {
                await commentService.GetByIdAsync(commentId);
                await commentService.ApproveAsync(commentId);
            }
            catch(NonExistentEntity ex)
            {
                return NotFound();
            }
            return RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> Reject(int commentId)
        {
            try
            {
                await commentService.GetByIdAsync(commentId);
                await commentService.RejectAsync(commentId);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("All");
        }
    }
}
