using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Service:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public bool ShowOnPage { get; set; }
    }
}
