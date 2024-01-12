using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDAL _skillEFDAL;

        public SkillManager(ISkillDAL skillEFDAL)
        {
            _skillEFDAL = skillEFDAL;
        }

        public IResult Add(Skill entity)
        {
            _skillEFDAL.Add(entity);
            return new SuccessResult("Skill added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _skillEFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity);
            return new SuccessResult("Skill deleted successfully");
        }

        public IDataResult<List<Skill>> GetAll()
        {
            return new SuccessDataResult<List<Skill>>(_skillEFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Skill> GetByID(int id)
        {
            return new SuccessDataResult<Skill>(_skillEFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Skill entity)
        {
            _skillEFDAL.Update(entity);
            return new SuccessResult("Skill updated successfully");
        }
    }
}
