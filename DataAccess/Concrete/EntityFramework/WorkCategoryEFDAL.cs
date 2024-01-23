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
    public class WorkCategoryEFDAL: RepositoryBase<WorkCategory, PortfolioDbContext>, IWorkCategoryDAL
    {
        private readonly PortfolioDbContext _context;

        public WorkCategoryEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public WorkCategory GetWorkCategoryWithPortfolios(Expression<Func<WorkCategory, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<WorkCategory>().Include(x => x.Portfolios).FirstOrDefault()
                  :
                  _context.Set<WorkCategory>().Include(x => x.Portfolios).FirstOrDefault(predicate);
        }
    }
}
