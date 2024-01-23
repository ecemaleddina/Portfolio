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
    public interface ISkillDAL:IRepository<Skill>
    {
        Skill GetSkillWithDetails(Expression<Func<Skill, bool>> predicate = null);
    }
}
