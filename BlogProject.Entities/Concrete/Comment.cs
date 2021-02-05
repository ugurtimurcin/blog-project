using BlogProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Entities.Concrete
{
    public class Comment : ITable
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
