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
        IDataResult<List<string>> Add(Portfolio entity);
        IDataResult<List<string>> Update(Portfolio entity);
        IResult Delete(int id);
        IDataResult<Portfolio> GetByID(int id);
        IDataResult<List<Portfolio>> GetAll();
    }
}
