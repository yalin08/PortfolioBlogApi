using Infrastructure.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Concrete
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public List<Comment>?  Comments { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser? AppUser { get; set; }

    }
}
