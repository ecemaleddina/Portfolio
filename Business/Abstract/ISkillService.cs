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
        IResult Add(Skill skill);
        IResult Update(Skill skill);
        IResult Delete(int id);
        IDataResult<Skill> GetByID(int id);
        IDataResult<List<Skill>> GetAll();
    }
}
