using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : BaseEntity, new()
    {
        IResult Add (T entity);
        IResult Delete (int id);
        IResult Update (T entity);
        IDataResult<T> GetByID (int id);
        IDataResult<List<T>> GetAll ();
    }
}
