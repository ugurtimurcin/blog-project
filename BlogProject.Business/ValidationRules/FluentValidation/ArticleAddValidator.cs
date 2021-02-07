using BlogProject.DTO.Concrete.ArticleDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.ValidationRules.FluentValidation
{
    public class ArticleAddValidator : AbstractValidator<ArticleAddDto>
    {
        public ArticleAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty").MinimumLength(10).WithMessage("Title must be longer than 10 characters").MaximumLength(75).WithMessage("Title must be shorter than 75 characters");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty").MinimumLength(20).WithMessage("Content must be longer than 20 characters");
            RuleFor(x => x.CategoryId).ExclusiveBetween(0, int.MaxValue).WithMessage("Choose a category");

        }
    }
}
