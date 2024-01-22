using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("Firstname is required.")
                                               .Length(1, 50).WithMessage("Firstname must be between 1 and 50 characters.");
            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("Lastname is required.")
                                               .Length(1, 50).WithMessage("Lastname must be between 1 and 50 characters.");
            RuleFor(entity => entity.WebSite).NotEmpty().WithMessage("Website URL is required.")
                                             .Length(1, 50).WithMessage("Website URL must be between 1 and 50 characters.");
            RuleFor(entity => entity.Description).NotEmpty().WithMessage("Description is required.")
                                                 .Length(1, 2000).WithMessage("Description must be between 1 and 2000 characters.");
            RuleFor(entity => entity.Address).NotEmpty().WithMessage("Address is required.")
                                             .Length(1, 100).WithMessage("Address must be between 1 and 100 characters.");
            RuleFor(entity => entity.Email).NotEmpty().WithMessage("Email is required.")
                                           .Length(1, 50).WithMessage("Email must be between 1 and 50 characters.");
            RuleFor(entity => entity.BirthDate).NotEmpty().WithMessage("Birthdate is required.");
            RuleFor(entity => entity.CvPath).NotEmpty().WithMessage("CV is required.");
            RuleFor(entity => entity.ProfilPath).NotEmpty().WithMessage("Profile image is required.");
            RuleFor(entity => entity.PositionID).NotEmpty().WithMessage("Position name is required.");
        }
    }
}
