using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(entity => entity.Name).NotEmpty().WithMessage("Name is required.")
                                          .Length(1, 50).WithMessage("Name must be between 1 and 50 characters.");
            RuleFor(entity => entity.Email).NotEmpty().WithMessage("Email is required.")
                                           .Length(1, 50).WithMessage("Email must be between 1 and 50 characters.");
            RuleFor(entity => entity.Messages).NotEmpty().WithMessage("Message is required.")
                                              .Length(1, 2000).WithMessage("Message must be between 1 and 2000 characters.");

        }
    }
}
