using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAboutSkillDAL: IRepository<AboutSkill>
    {
        List<AboutSkill> GetSkillDetailWithSkill(Expression<Func<AboutSkill, bool>> predicate = null);
    }
}
