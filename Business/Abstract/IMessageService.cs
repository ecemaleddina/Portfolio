using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<List<string>> Add(Message entity);
        IDataResult<List<string>> Update(Message entity);
        IResult Delete(int id);
        IDataResult<Message> GetByID(int id);
        IDataResult<List<Message>> GetAll();
    }
}
