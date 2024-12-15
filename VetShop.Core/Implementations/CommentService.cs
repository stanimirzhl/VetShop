using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using VetShop.Core.Interfaces;
using Microsoft.Extensions.Logging;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;
using System.Security.Claims;
using static VetShop.Infrastructure.Constants.DataConstants.CommentStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace VetShop.Core.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;
        private ILogger<CommentService> logger;

        public CommentService(IRepository<Comment> repository, ILogger<CommentService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task AddCommentAsync(int productId, CommentServiceModel commentForm)
        {
            var newComment = new Comment
            {
                ProductId = productId,
                Title = commentForm.Title,
                Description = commentForm.Description,
                AuthorId = commentForm.AuthorId
            };

            await repository.AddAsync(newComment);
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
           var comment = await repository.GetByIdAsync(id) ?? throw new NonExistentEntity($"Comment with ID {id} not found.");

            return comment;
        }

        public async Task<PagingModel<CommentServiceModel>> GetPagedCommentsAsync(int productId, int pageIndex, int pageSize)
        {
            var query = repository.All()
             .Where(c => c.ProductId == productId && c.Status == Approved)
             .OrderByDescending(c => c.CreatedOn)
             .Select(c => new CommentServiceModel
             {
                 Id = c.Id,
                 AuthorName = c.Author.FirstName + " " + c.Author.LastName ?? "Anonymous",
                 Title = c.Title,
                 Description = c.Description,
                 CreatedOn = c.CreatedOn,
                 ProductId = productId
             });

            return await PagingModel<CommentServiceModel>.CreateAsync(query, pageIndex, pageSize);
        }
        public async Task<PagingModel<CommentServiceModel>> GetAllPagedCommentsAsync(int pageIndex, int pageSize)
        {
            var query = repository.All()
             .Where(c => c.Status == Pending)
             .OrderByDescending(c => c.CreatedOn)
             .Select(c => new CommentServiceModel
             {
                 Id = c.Id,
                 AuthorName = c.Author.FirstName + " " + c.Author.LastName ?? "Anonymous",
                 Title = c.Title,
                 Description = c.Description,
                 CreatedOn = c.CreatedOn,
             });

            return await PagingModel<CommentServiceModel>.CreateAsync(query, pageIndex, pageSize);
        }
        public async Task ApproveAsync(int commentId)
        {
            var comment = await this.GetByIdAsync(commentId) ?? throw new NonExistentEntity($"Comment with ID {commentId} not found.");
            comment.Status = Approved;
            await repository.SaveChangesAsync();
        }

        public async Task RejectAsync(int commentId)
        {
            var comment = await this.GetByIdAsync(commentId) ?? throw new NonExistentEntity($"Comment with ID {commentId} not found.");
            await repository.DeleteAsync(commentId);
            await repository.SaveChangesAsync();
        }
    }
    
}
