using AutoMapper;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Business.Dto.Comment;
using Business.Dto.Post;
using Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Interface;

namespace Business.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepo commentRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }


        public async Task<bool> DeleteComment(int id)
        {
            var comment = await _commentRepo.GetDefault(x => x.Id == id );
            if (comment != null)
            {
                await _commentRepo.Delete(comment);
                return true;
            }
                return false;
        }


        public async Task<bool> CreateComment(CommentDto model)
        {
            var com = _mapper.Map<Comment>(model);
            com.PostedDate = DateTime.Now;
            var created= await _commentRepo.Create(com);
            if (created != null)
                return true;
          

                return false;
        }

        public async Task<List<CommentDto>> GetCommentByPostId(int postId)
        {
            var comments = await _commentRepo.GetDefaults(x => x.PostId == postId && x.IsActive);
            var dtos = comments.Select(p => _mapper.Map<CommentDto>(p)).ToList();
            return dtos;
        }

    }
}
