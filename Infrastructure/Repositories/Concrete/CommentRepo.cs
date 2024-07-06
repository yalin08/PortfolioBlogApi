using Infrastructure.Context;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Concrete
{
    public class CommentRepo : BaseRepo<Comment>
    {
        public CommentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
