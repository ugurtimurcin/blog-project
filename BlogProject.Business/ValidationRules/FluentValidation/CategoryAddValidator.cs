using BlogProject.DTO.Concrete.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator: AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name cannot be empty!").MaximumLength(75).WithMessage("Category name must be longer than 75 characters");
        }
    }
}
