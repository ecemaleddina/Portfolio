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
        IDataResult<List<string>> Add(Person entity, string imageFile, string cvFile);
        IDataResult<List<string>> Update(Person entity, string imageFile, string cvFile);
        IResult Delete(int id);
        IDataResult<Person> GetByID(int id);
        IDataResult<List<Person>> GetAll();
    }
}
