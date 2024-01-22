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
    public class AboutSkillManager : IAboutSkillService
    {
        private readonly IAboutSkillDAL _eFDAL;
        private readonly IValidator<AboutSkill> _validator;

        public AboutSkillManager(IAboutSkillDAL eFDAL, IValidator<AboutSkill> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(AboutSkill entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            _eFDAL.Add(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Skill detail added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _eFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity);
            return new SuccessResult("Skill detail deleted successfully");
        }

        public IDataResult<List<AboutSkill>> GetAll()
        {
            return new SuccessDataResult<List<AboutSkill>>(_eFDAL.GetSkillDetailWithSkill(x => x.Deleted == 0).ToList());
        }

        public IDataResult<AboutSkill> GetByID(int id)
        {
            return new SuccessDataResult<AboutSkill>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(AboutSkill entity)
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
            return new SuccessDataResult<List<string>>(new List<string>(), "Skill detail updated successfully");
        }
    }
}