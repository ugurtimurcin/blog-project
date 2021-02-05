using BlogProject.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DTO.Concrete.AppUserDTOs
{
    public class AppUserPasswordChangeDto : IDto
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
