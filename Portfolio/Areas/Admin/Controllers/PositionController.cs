using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionManager;

        public PositionController(IPositionService positionManager)
        {
            _positionManager = positionManager;
        }

        public IActionResult Index()
        {
            var positions = _positionManager.GetAll().Data;
            return View(positions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            _positionManager.Add(position);

            return Redirect("Index");
        }

        public IActionResult Delete(int id)
        {
            _positionManager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var position = _positionManager.GetByID(id).Data;
            return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            _positionManager.Update(position);
            return RedirectToAction("Index");
        }
    }
}
