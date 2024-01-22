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
    public class PositionValidator: AbstractValidator<Position>
    {
        private readonly IPositionDAL _positionDAL;

        public PositionValidator(IPositionDAL positionDAL)
        {
            _positionDAL = positionDAL;

            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 50).WithMessage("Name must be between 1 and 50 characters.")
                .Must(BeUniqueName).WithMessage("Name must be unique.");
        }

        private bool BeUniqueName(string name)
        {
            return !_positionDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
        }
    }
}
