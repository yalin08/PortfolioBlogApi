using Infrastructure.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Concrete
{
    public class CommentRequest:BaseEntity
    {
        public string Sender { get; set; }
        public string SenderIp { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedDate { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
