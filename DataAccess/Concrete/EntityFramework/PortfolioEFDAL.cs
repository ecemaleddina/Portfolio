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
    public class PortfolioEFDAL : RepositoryBase<Portfolio, PortfolioDbContext>, IPortfolioDAL
    {
        private readonly PortfolioDbContext _context;

        public PortfolioEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public List<Portfolio> GetPortfolioWithWorkCategory(Expression<Func<Portfolio, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Portfolio>().Include(x => x.WorkCategory).ToList()
                  :
                  _context.Set<Portfolio>().Include(x => x.WorkCategory).Where(predicate).ToList();
        }
    }
}
