using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutSkillService
    {
        IDataResult<List<string>> Add(AboutSkill entity);
        IDataResult<List<string>> Update(AboutSkill entity);
        IResult Delete(int id);
        IDataResult<AboutSkill> GetByID(int id);
        IDataResult<List<AboutSkill>> GetAll();
    }
}
