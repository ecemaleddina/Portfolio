using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class SkillValidator: AbstractValidator<Skill>
    {
        private readonly ISkillDAL _skillDAL;

        public SkillValidator(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;

            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 500).WithMessage("Name must be between 1 and 500 characters.")
                .Must(BeUniqueName).WithMessage("Name must be unique.");
        }

        private bool BeUniqueName(string name)
        {
            return !_skillDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
        }
    }
}
