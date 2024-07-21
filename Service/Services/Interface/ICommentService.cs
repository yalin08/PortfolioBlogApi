using Business.Dto.Comment;
using Business.Dto.CommentRequest;
using Infrastructure.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentRequestDto model);
        Task<bool> DeleteComment(int id);
        Task<List<CommentDto>> GetCommentByPostId(int postId);
        Task<List<CreateCommentDto>> GetAllComments();
    }
}
