using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDAL _positionEFDAL;

        public PositionManager(IPositionDAL positionEFDAL)
        {
            _positionEFDAL = positionEFDAL;
        }

        public IResult Add(Position entity)
        {
            _positionEFDAL.Add(entity);
            return new SuccessResult("Position added successfully");
        }

        public IResult Delete(int id)
        {
            var oldEntity = _positionEFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity);
            return new SuccessResult("Position deleted successfully");
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionEFDAL.GetAll(x=> x.Deleted == 0).ToList());
        }

        public IDataResult<Position> GetByID(int id)
        {
            return new SuccessDataResult<Position>(_positionEFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IResult Update(Position entity)
        {
            _positionEFDAL.Update(entity);
            return new SuccessResult("Position updated successfully");
        }
    }
}
