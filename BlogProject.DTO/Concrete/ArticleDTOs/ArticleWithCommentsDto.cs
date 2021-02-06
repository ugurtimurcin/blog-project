using BlogProject.DTO.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DTO.Concrete.ArticleDTOs
{
    public class ArticleWithCommentsDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
