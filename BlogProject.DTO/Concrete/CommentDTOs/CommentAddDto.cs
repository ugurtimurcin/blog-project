using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DTO.Concrete.CommentDTOs
{
    public class CommentAddDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        public int ArticleId { get; set; }
    }
}
