using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(entity => entity.CompanyName).NotEmpty().WithMessage("Company name is required.")
                                           .Length(1, 500).WithMessage("Company name must be between 1 and 500 characters.");
            RuleFor(entity => entity.Description).NotEmpty().WithMessage("Description is required.")
                                                 .Length(1, 2000).WithMessage("Description must be between 1 and 2000 characters.");
            RuleFor(entity => entity.EntryDate).NotEmpty().WithMessage("Entrydate is required.");
            RuleFor(entity => entity.PositionId).NotEmpty().WithMessage("Position name is required.");
        }
    }
}
