using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personManager;
        private readonly IPositionService _positionManager;

        public PersonController(IPersonService personManager, IPositionService positionManager)
        {
            _personManager = personManager;
            _positionManager = positionManager;
        }

        public IActionResult Index()
        {
            
            var people = _personManager.GetAll().Data;
            return View(people);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var positionsData = _positionManager.GetAll().Data;

            if (positionsData != null)
            {
                ViewData["Positions"] = new SelectList(positionsData, "ID", "Name");
            }
            else
            {
                ViewData["Positions"] = new SelectList(new List<Position>(), "ID", "Name");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            _personManager.Add(person);

            return Redirect("Index");
        }

        public IActionResult Delete(int id)
        {
            _personManager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var positionsData = _positionManager.GetAll().Data;

            if (positionsData != null)
            {
                ViewData["Positions"] = new SelectList(positionsData, "ID", "Name");
            }
            else
            {
                ViewData["Positions"] = new SelectList(new List<Position>(), "ID", "Name");
            }
            var person = _personManager.GetByID(id).Data;
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _personManager.Update(person);
            return RedirectToAction("Index");
        }
    }
}
