using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillManager;

        public SkillController(ISkillService skillManager)
        {
            _skillManager = skillManager;
        }

        public IActionResult Index()
        {
            var skills = _skillManager.GetAll().Data;
            return View(skills);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            _skillManager.Add(skill);

            return Redirect("Index");
        }

        public IActionResult Delete(int id)
        {
            _skillManager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var skill = _skillManager.GetByID(id).Data;
            return View(skill);
        }

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            _skillManager.Update(skill);
            return RedirectToAction("Index");
        }
    }
}
