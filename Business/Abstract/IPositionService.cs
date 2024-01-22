using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IDataResult<List<string>> Add(Position entity);
        IDataResult<List<string>> Update(Position entity);
        IResult Delete(int id);
        IDataResult<Position> GetByID(int id);
        IDataResult<List<Position>> GetAll();
    }
}
