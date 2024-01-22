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
    public class AboutSkillEFDAL : RepositoryBase<AboutSkill, PortfolioDbContext>, IAboutSkillDAL
    {

        private readonly PortfolioDbContext _context;

        public AboutSkillEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public List<AboutSkill> GetSkillDetailWithSkill(Expression<Func<AboutSkill, bool>> predicate = null)
        {
           
            return predicate is null
                  ?
                   _context.Set<AboutSkill>().Include(x=>x.Skill).ToList()
                  :
                  _context.Set<AboutSkill>().Include(x => x.Skill).Where(predicate).ToList();
        }
    }
}
