using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkCategoryService
    {
        IDataResult<List<string>> Add(WorkCategory entity);
        IDataResult<List<string>> Update(WorkCategory entity);
        IResult Delete(int id);
        IDataResult<WorkCategory> GetByID(int id);
        IDataResult<List<WorkCategory>> GetAll();
    }
}
