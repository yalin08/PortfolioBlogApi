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
    public interface ICommentRequestService
    {
        Task<bool> CreateCommentRequest(CreateCommentRequestDto model);
        Task<bool> DeleteCommentRequest(int id);

        Task<CommentRequestDto> GetCommentRequest(int id);
        Task<List<CommentRequestDto>> GetCommentRequestsByPostId(int postId);
        Task<List<CommentRequestDto>> GetAllCommentRequests();
    }
}
