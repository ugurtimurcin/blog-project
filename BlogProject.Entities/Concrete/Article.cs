using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Entities.Concrete
{
    public class Article : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
