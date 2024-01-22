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
    public class ExperienceEFDAL : RepositoryBase<Experience, PortfolioDbContext>, IExperienceDAL
    {
        private readonly PortfolioDbContext _context;

        public ExperienceEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public List<Experience> GetExperienceWithPosition(Expression<Func<Experience, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Experience>().Include(x => x.Position).ToList()
                  :
                  _context.Set<Experience>().Include(x => x.Position).Where(predicate).ToList();
        }
    }
}
