using Business.Dto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentDto model);
        Task<bool> DeleteComment(int id);
        Task<List<CommentDto>> GetCommentByPostId(int postId);
    }
}
