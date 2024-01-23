using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SkillEFDAL: RepositoryBase<Skill, PortfolioDbContext>, ISkillDAL
    {
        private readonly PortfolioDbContext _context;

        public SkillEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public Skill GetSkillWithDetails(Expression<Func<Skill, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Skill>().Include(x => x.AboutSkills).FirstOrDefault()
                  :
                  _context.Set<Skill>().Include(x => x.AboutSkills).FirstOrDefault(predicate);
        }
    }
}
