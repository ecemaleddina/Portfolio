using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person, string imageFile, string cvFile);
        IResult Update(Person person, string imageFile, string cvFile);
        IResult Delete(int id);
        IDataResult<Person> GetByID(int id);
        IDataResult<List<Person>> GetAll();
    }
}
