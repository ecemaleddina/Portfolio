using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutSkillController : Controller
    {
        private readonly IAboutSkillService _manager;
        private readonly ISkillService _skillManager;

        public AboutSkillController(IAboutSkillService manager, ISkillService skillManager)
        {
            _manager = manager;
            _skillManager = skillManager;
        }

        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data;
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var skillsData = _skillManager.GetAll().Data;

            if (skillsData.Count != 0)
            {
                ViewData["Skills"] = new SelectList(skillsData, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some skill";
                return Redirect("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(AboutSkill entity)
        {
            var result = _manager.Add(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var skillsData = _skillManager.GetAll().Data;

                ViewData["Skills"] = new SelectList(skillsData, "ID", "Name");
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
            var skillsData = _skillManager.GetAll().Data;

            if (skillsData.Count != 0)
            {
                ViewData["Skills"] = new SelectList(skillsData, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some skill";
                return Redirect("Index");
            }

            var position = _manager.GetByID(id).Data;
            return View(position);
        }

        [HttpPost]
        public IActionResult Edit(AboutSkill entity)
        {
            var result = _manager.Update(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var skillsData = _skillManager.GetAll().Data;

                ViewData["Skills"] = new SelectList(skillsData, "ID", "Name");
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
