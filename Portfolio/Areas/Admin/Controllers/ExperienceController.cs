using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _manager;
        private readonly IPositionService _positionManager;

        public ExperienceController(IExperienceService manager, IPositionService positionManager)
        {
            _manager = manager;
            _positionManager = positionManager;
        }

        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data;
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var positionsdata = _positionManager.GetAll().Data;

            if (positionsdata.Count != 0)
            {
                ViewData["Positions"] = new SelectList(positionsdata, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some positions";
                return Redirect("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Experience entity)
        {
            var result = _manager.Add(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var positionsdata = _positionManager.GetAll().Data;

                ViewData["Positions"] = new SelectList(positionsdata, "ID", "Name");
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(entity);
            }
        }

        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var positionsdata = _positionManager.GetAll().Data;

            if (positionsdata.Count != 0)
            {
                ViewData["Positions"] = new SelectList(positionsdata, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some positions";
                return Redirect("Index");
            }

            var position = _manager.GetByID(id).Data;
            return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Experience entity)
        {
            var result = _manager.Update(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var positionsdata = _positionManager.GetAll().Data;

                ViewData["Positions"] = new SelectList(positionsdata, "ID", "Name");
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(entity);
            }
        }
    }
}
