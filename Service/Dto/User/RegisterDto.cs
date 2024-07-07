using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.User
{
    public class RegisterDto
    {
        public string Email => "yalintuzmen08@gmail.com";
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
