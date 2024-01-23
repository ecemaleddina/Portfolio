using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        IDataResult<List<string>> Add(Portfoli entity, string fileName);
        IDataResult<List<string>> Update(Portfoli entity, string fileName);
        IResult Delete(int id);
        IDataResult<Portfoli> GetByID(int id);
        IDataResult<List<Portfoli>> GetAll();
    }
}
