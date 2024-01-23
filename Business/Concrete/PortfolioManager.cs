using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PortfolioManager: IPortfolioService
    {
        private readonly IPortfolioDAL _eFDAL;
        private readonly IValidator<Portfoli> _validator;

        public PortfolioManager(IPortfolioDAL eFDAL, IValidator<Portfoli> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(Portfoli entity, string fileName)
        {
            entity.WorkImgPath = fileName;
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            _eFDAL.Add(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Portfolio added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _eFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity, oldEntity.WorkImgPath);
            return new SuccessResult("Portfolio deleted successfully");
        }

        public IDataResult<List<Portfoli>> GetAll()
        {
            return new SuccessDataResult<List<Portfoli>>(_eFDAL.GetPortfolioWithWorkCategory(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Portfoli> GetByID(int id)
        {
            return new SuccessDataResult<Portfoli>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Portfoli entity, string fileName)
        {
            entity.WorkImgPath = fileName;
            if (entity.Deleted == 0)
            {
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
            }

            _eFDAL.Update(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Skill detail updated successfully");
        }
    }
}
