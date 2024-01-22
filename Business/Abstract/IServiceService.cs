using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IDataResult<List<string>> Add(Service entity);
        IDataResult<List<string>> Update(Service entity);
        IResult Delete(int id);
        IDataResult<Service> GetByID(int id);
        IDataResult<List<Service>> GetAll();
    }
}
