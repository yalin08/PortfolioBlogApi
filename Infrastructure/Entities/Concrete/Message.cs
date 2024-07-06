using Infrastructure.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Concrete
{
    public class Message:BaseEntity
    {
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
