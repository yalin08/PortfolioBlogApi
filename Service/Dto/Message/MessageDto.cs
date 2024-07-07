using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.Message
{
    public class MessageDto
    {
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }

    }
}
