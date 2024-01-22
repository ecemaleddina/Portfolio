using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkCategoryManager: IWorkCategoryService
    {
        private readonly IWorkCategoryDAL _eFDAL;
        private readonly IValidator<WorkCategory> _validator;

        public WorkCategoryManager(IWorkCategoryDAL eFDAL, IValidator<WorkCategory> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(WorkCategory entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            _eFDAL.Add(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Work category added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _eFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity);
            return new SuccessResult("Work category deleted successfully");
        }

        public IDataResult<List<WorkCategory>> GetAll()
        {
            return new SuccessDataResult<List<WorkCategory>>(_eFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<WorkCategory> GetByID(int id)
        {
            return new SuccessDataResult<WorkCategory>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(WorkCategory entity)
        {
            if (entity.Deleted == 0)
            {
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
            }

            _eFDAL.Update(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Work category updated successfully");
        }
    }
}
