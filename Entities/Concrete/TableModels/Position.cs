using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Position:BaseEntity
    {
        public Position()
        {
            People = new List<Person> { };
        }
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}
