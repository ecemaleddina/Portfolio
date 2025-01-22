using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _manager;
        private readonly IPositionService _positionManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonController(IPersonService manager, IPositionService positionManager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _positionManager = positionManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var datas = _manager.GetAll().Data;
            return View(datas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var positionsData = _positionManager.GetAll().Data;

            if (positionsData.Count != 0)
            {
                ViewData["Positions"] = new SelectList(positionsData, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some position";
                return Redirect("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            string fileName = Uploader(person, "Image", person.ImageFile);
            string cvFile = Uploader(person, "CV", person.CvFile);

            var result = _manager.Add(person, fileName, cvFile);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var positionsData = _positionManager.GetAll().Data;

                ViewData["Positions"] = new SelectList(positionsData, "ID", "Name");
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(person);
            }
        }

        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
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
                TempData["AlertMessage"] = "Firstly you must add some position";
                return Redirect("Index");
            }
            var person = _manager.GetByID(id).Data;
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var existingPerson = _manager.GetByID(person.ID).Data;

            string fileName = person.ImageFile != null ? Uploader(person, "Image", person.ImageFile)
                                                       : existingPerson.ProfilPath;
            string cvFile = person.CvFile != null ? Uploader(person, "CV", person.CvFile)
                                                  : existingPerson.CvPath;

            var result = _manager.Update(person, fileName, cvFile);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var positionsData = _positionManager.GetAll().Data;

                ViewData["Positions"] = new SelectList(positionsData, "ID", "Name");
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(person);
            }

        }

        private string Uploader(Person person, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                document.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}
