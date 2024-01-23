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
    public class PositionEFDAL:RepositoryBase<Position, PortfolioDbContext>, IPositionDAL
    {
        private readonly PortfolioDbContext _context;

        public PositionEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public Position GetPositionWithExpsandPeople(Expression<Func<Position, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Position>().Include(x => x.Experiences).Include(x => x.People).FirstOrDefault()
                  :
                  _context.Set<Position>().Include(x => x.Experiences).Include(x => x.People).FirstOrDefault(predicate);
        }
    }
}
