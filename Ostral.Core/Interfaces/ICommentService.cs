using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Interfaces
{
    public interface ICommentService
    {
       
        Task<ResponseVM<CommentResponse>> GetCommentById(string commentId);
        Task<ResponseVM<CommentResponse>> AddCommentAsync(string courseId, string comment, string userId);
        Task<ResponseVM<CommentResponse>> ToggleLikeAsync(string commentId, string userId);

        Task<ResponseVM<IEnumerable<CommentListItem>>> GetAllCommentsAsync(string courseId);

    }
}
