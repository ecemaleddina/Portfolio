using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Skill:BaseEntity
    {
        public Skill()
        {
            AboutSkills = new List<AboutSkill> { };
        }
        public string Name { get; set; }
        public List<AboutSkill> AboutSkills  { get; set; }
    }
}
