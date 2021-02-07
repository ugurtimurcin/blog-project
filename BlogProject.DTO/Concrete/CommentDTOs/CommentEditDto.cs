using BlogProject.Core.Entities;
using BlogProject.DTO.Concrete.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DTO.Concrete.CommentDTOs
{
    public class CommentEditDto : IDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        public ArticleListDto Article { get; set; }
    }
}
