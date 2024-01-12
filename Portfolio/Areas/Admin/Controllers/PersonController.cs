using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personManager;
        private readonly IPositionService _positionManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonController(IPersonService personManager, IPositionService positionManager, IWebHostEnvironment webHostEnvironment)
        {
            _personManager = personManager;
            _positionManager = positionManager;
            _webHostEnvironment = webHostEnvironment;
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
            string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;
            if (person.ImageFile != null)
            {
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            string cvFile = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
            if (person.CvFile != null)
            {
                string folder = "CV/";
                folder += cvFile;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            _personManager.Add(person, fileName, cvFile);
            return RedirectToAction("Index");
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
            string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;
            if (person.ImageFile != null)
            {
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            string cvFile = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
            if (person.CvFile != null)
            {
                string folder = "CV/";
                folder += cvFile;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            _personManager.Update(person, fileName, cvFile);
            return RedirectToAction("Index");
        }
    }
}
