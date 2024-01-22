using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        IDataResult<List<string>> Add(Experience entity);
        IDataResult<List<string>> Update(Experience entity);
        IResult Delete(int id);
        IDataResult<Experience> GetByID(int id);
        IDataResult<List<Experience>> GetAll();
    }
}
