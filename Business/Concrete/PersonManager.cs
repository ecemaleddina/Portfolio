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

        public IResult Add(Person person, string imageFile, string cvFile)
        {
            person.ProfilPath = imageFile;
            person.CvPath = cvFile;
            _personEFDAL.Add(person);
            return new SuccessResult("Position added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _personEFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity, oldEntity.ProfilPath, oldEntity.CvPath);
            return new SuccessResult("Position deleted successfully");
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personEFDAL.GetPersonWithPosition(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Person> GetByID(int id)
        {
            return new SuccessDataResult<Person>(_personEFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Person person, string imageFile, string cvFile)
        {
            person.ProfilPath = imageFile;
            person.CvPath = cvFile;
            _personEFDAL.Update(person);
            return new SuccessResult("Position updated successfully");
        }
    }
}
