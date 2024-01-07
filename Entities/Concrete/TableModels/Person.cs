using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName +" "+ LastName;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get;set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public string ProfilPath { get; set; }
        public string CvPath { get; set; }
        public Position Position { get; set; }
    }
}
