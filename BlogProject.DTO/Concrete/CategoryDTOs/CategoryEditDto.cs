using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DTO.Concrete.CategoryDTOs
{
    public class CategoryEditDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
