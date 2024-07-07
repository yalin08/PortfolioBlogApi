using Business.Dto.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface IPostService
    {
        Task<bool> CreatePost(PostDto dto);
        Task<PostDto> GetPostById(int id);

        Task<bool> DeletePost(int id);

        Task<List<PostDto>> GetPosts();
        Task<List<PostDto>> GetPosts(int page, int pageSize);
    }
}
