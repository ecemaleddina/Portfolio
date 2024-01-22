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
    public class AboutSkillValidator : AbstractValidator<AboutSkill>
    {

        public AboutSkillValidator()
        {
            RuleFor(entity => entity.Point).NotEmpty().WithMessage("Skill percentage is required.");
            RuleFor(entity => entity.SkillId).NotEmpty().WithMessage("Skill name is required.");
        }
    }
}
