using Business.Abstract;
using Business.Validations;
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
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _eFDAL;
        private readonly IValidator<Person> _validator;

        public PersonManager(IPersonDAL eFDAL, IValidator<Person> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(Person entity, string imageFile, string cvFile)
        {
            entity.ProfilPath = imageFile;
            entity.CvPath = cvFile;

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            _eFDAL.Add(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Person added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _eFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity, oldEntity.ProfilPath, oldEntity.CvPath);
            return new SuccessResult("Person deleted successfully");
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_eFDAL.GetPersonWithPosition(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Person> GetByID(int id)
        {
            return new SuccessDataResult<Person>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Person entity, string imageFile, string cvFile)
        {
            entity.ProfilPath = imageFile;
            entity.CvPath = cvFile;

            if (entity.Deleted == 0)
            {
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
            }

            _eFDAL.Update(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), "Person updated successfully");
        }
    }
}
