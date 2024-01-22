using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class WorkCategory:BaseEntity
    {
        public WorkCategory()
        {
            Portfolios = new List<Portfolio> { };
        }
        public string Name { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
