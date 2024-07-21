using AutoMapper;
using Business.Dto.Comment;
using Business.Dto.CommentRequest;
using Business.Services.Interface;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Infrastructure.Repositories.Interface;
using System.Xml.Linq;

namespace Business.Services.Concrete
{
    public class CommentRequestService : ICommentRequestService
    {

        private readonly ICommentRequestRepo _commentRequestRepo;
        private readonly IMapper _mapper;

        public CommentRequestService(ICommentRequestRepo commentRepo, IMapper mapper)
        {
            _commentRequestRepo = commentRepo;
            _mapper = mapper;
        }


        public async Task<bool> CreateCommentRequest(CreateCommentRequestDto dto)
        {
            var model=_mapper.Map<CommentRequest>(dto);
            model.PostedDate = DateTime.Now;
            var created = await _commentRequestRepo.Create(model);
            if (created != null)
                return true;


            return false;
        }

        public async Task<bool> DeleteCommentRequest(int id)
        {
            var comment = await _commentRequestRepo.GetDefault(x => x.Id == id);
            if (comment != null)
            {
                await _commentRequestRepo.Delete(comment);
                return true;
            }
            return false;
        }

        public async Task<List<CommentRequestDto>> GetAllCommentRequests()
        {
            var comments = await _commentRequestRepo.GetDefaults(x => x.IsActive);
            var dtos =comments.Select(x=>_mapper.Map<CommentRequestDto>(x)).ToList();
            return dtos;
        }

        public async Task<CommentRequestDto> GetCommentRequest(int id)
        {
            var comment = await _commentRequestRepo.GetDefault(x => x.Id == id );
            var dto = _mapper.Map<CommentRequestDto>(comment);
            return dto;
        }

        public async Task<List<CommentRequestDto>> GetCommentRequestsByPostId(int postId)
        {
            var comments = await _commentRequestRepo.GetDefaults(x => x.PostId == postId && x.IsActive);

            var dtos=comments.Select(x=>_mapper.Map<CommentRequestDto>(x)).OrderByDescending(x => x.PostedDate).ToList();
            return dtos;
        }


    }
}
