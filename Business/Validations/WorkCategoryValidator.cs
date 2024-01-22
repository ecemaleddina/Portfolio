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
    public class WorkCategoryValidator: AbstractValidator<WorkCategory>
    {
        private readonly IWorkCategoryDAL _workCategoryDAL;

        public WorkCategoryValidator(IWorkCategoryDAL workCategoryDAL)
        {
            _workCategoryDAL = workCategoryDAL;

            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.")
                .Must(BeUniqueName).WithMessage("Name must be unique.");
        }

        private bool BeUniqueName(string name)
        {
            return !_workCategoryDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
        }
    }
}
