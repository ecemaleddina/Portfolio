using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personEFDAL;

        public PersonManager(IPersonDAL personEFDAL)
        {
            _personEFDAL = personEFDAL;
        }

        public IResult Add(Person entity)
        {
            _personEFDAL.Add(entity);
            return new SuccessResult("Position added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _personEFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity);
            return new SuccessResult("Position deleted successfully");
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personEFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Person> GetByID(int id)
        {
            return new SuccessDataResult<Person>(_personEFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Person entity)
        {
            _personEFDAL.Update(entity);
            return new SuccessResult("Position updated successfully");
        }
    }
}
