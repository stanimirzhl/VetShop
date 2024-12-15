using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface ICommentService
    {
        Task<PagingModel<CommentServiceModel>> GetPagedCommentsAsync(int productId,int pageIndex, int pageSize);
        Task<PagingModel<CommentServiceModel>> GetAllPagedCommentsAsync(int pageIndex, int pageSize);
        Task<Comment?> GetByIdAsync(int id);
        Task AddCommentAsync(int productId, CommentServiceModel commentForm);
        Task RejectAsync(int commentId);
        Task ApproveAsync(int commentId);
    }
}
