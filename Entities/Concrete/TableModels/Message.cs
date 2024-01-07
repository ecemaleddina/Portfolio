using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Message:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Messages { get; set; }
        public DateTime InsertDate { get; set; }

    }
}
