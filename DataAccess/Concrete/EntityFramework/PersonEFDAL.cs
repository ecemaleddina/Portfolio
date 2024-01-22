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
    public class PersonEFDAL : RepositoryBase<Person, PortfolioDbContext>, IPersonDAL
    {

        private readonly PortfolioDbContext _context;

        public PersonEFDAL(PortfolioDbContext context)
        {
            _context = context;
        }

        public List<Person> GetPersonWithPosition(Expression<Func<Person, bool>> predicate = null)
        {
           
            return predicate is null
                  ?
                   _context.Set<Person>().Include(x=>x.Position).ToList()
                  :
                  _context.Set<Person>().Include(x => x.Position).Where(predicate).ToList();
        }
    }
}
