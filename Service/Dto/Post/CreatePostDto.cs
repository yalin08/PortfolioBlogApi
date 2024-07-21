using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.Post
{
    public class CreatePostDto
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
