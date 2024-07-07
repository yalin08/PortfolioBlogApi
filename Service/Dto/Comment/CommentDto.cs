using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.Comment
{
    public class CommentDto
    {

        public string Sender { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedDate { get; set; }
        public int PostId { get; set; }
    }
}
