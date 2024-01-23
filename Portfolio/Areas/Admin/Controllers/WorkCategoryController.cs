using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkCategoryController : Controller
    {
        private readonly IWorkCategoryService _manager;

        public WorkCategoryController(IWorkCategoryService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data;
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(WorkCategory entity)
        {
            var result = _manager.Add(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
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
            if(_manager.GetByID(id).Data.Portfolios.Count != 0)
            {
                TempData["AlertMessage"] = "You have portfolio(s) with this category. Delete them firstly!";
                return RedirectToAction("Index");
            }
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var skill = _manager.GetByID(id).Data;
            return View(skill);
        }

        [HttpPost]
        public IActionResult Edit(WorkCategory entity)
        {
            var result = _manager.Update(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
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
