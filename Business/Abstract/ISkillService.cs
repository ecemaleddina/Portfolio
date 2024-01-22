using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillService
    {
        IDataResult<List<string>> Add(Skill entity);
        IDataResult<List<string>> Update(Skill entity);
        IResult Delete(int id);
        IDataResult<Skill> GetByID(int id);
        IDataResult<List<Skill>> GetAll();
    }
}
