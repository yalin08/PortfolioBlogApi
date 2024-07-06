using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Comment
{
    public class CommentDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedDate => DateTime.Now;
        public int PostId { get; set; }
    }
}
