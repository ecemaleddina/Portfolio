using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ServiceValidator:AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(entity => entity.Title).NotEmpty().WithMessage("Title is required.")
                                           .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");
            RuleFor(entity => entity.Description).NotEmpty().WithMessage("Description is required.")
                                                 .Length(1, 2000).WithMessage("Description must be between 1 and 2000 characters.");
            RuleFor(entity => entity.IconName).NotEmpty().WithMessage("Icon name is required.")
                                                 .Length(1, 500).WithMessage("Icon name must be between 1 and 500 characters.");
        }
    }
}
