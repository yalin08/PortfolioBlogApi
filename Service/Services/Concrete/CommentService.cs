using AutoMapper;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Service.Dto.Comment;
using Service.Dto.Post;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepo _commentRepo;
        private readonly PostRepo _postRepo;
        private readonly IMapper _mapper;

        public CommentService(CommentRepo commentRepo, PostRepo postRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
            _mapper = mapper;
        }


        public async Task CreateComment(CommentDto model)
        {
            var com = _mapper.Map<Comment>(model);
            com.PostedDate = DateTime.Now;
            await _commentRepo.Create(com);
        }

        public async Task<List<CommentDto>> GetCommentByPostId(int postId)
        {
            var comments = await _commentRepo.GetDefaults(x => x.PostId == postId);
            var dtos = comments.Select(p => _mapper.Map<CommentDto>(p)).ToList();
            return dtos;
        }

    }
}
