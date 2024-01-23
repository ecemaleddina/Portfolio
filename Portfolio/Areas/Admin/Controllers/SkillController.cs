using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _manager;

        public SkillController(ISkillService manager)
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
        public IActionResult Add(Skill entity)
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
            if (_manager.GetByID(id).Data.AboutSkills.Count != 0)
            {
                TempData["AlertMessage"] = "You have skill detail(s) with this skill. Delete them firstly!";
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
        public IActionResult Edit(Skill entity)
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
