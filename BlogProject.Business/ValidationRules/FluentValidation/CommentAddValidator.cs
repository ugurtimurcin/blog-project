using BlogProject.DTO.Concrete.CommentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("First name cannot be empty!").MaximumLength(20).WithMessage("First name must be shorter than 20 characters");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("First name cannot be empty!").MaximumLength(20).WithMessage("Last name must be shorter than 25 characters");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Comment cannot be empty!").MinimumLength(10).WithMessage("Comment must be longer than 10 characters").MaximumLength(1150).WithMessage("Comment must be shorter than 1150 characters");
        }
    }
}
