using Service.Dto.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IPostService
    {
        Task CreatePost(CreatePostDto dto);
        Task<PostDto> GetPostById(int id);
        Task<List<PostDto>> GetPosts();
        Task<List<PostDto>> GetPosts(int page, int pageSize);
    }
}
