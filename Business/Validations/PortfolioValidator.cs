using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(entity => entity.Title).NotEmpty().WithMessage("Title is required.")
                                           .Length(1, 50).WithMessage("Title must be between 1 and 50 characters.");
            RuleFor(entity => entity.CategoryId).NotEmpty().WithMessage("Category name is required.");
        }
    }
}
