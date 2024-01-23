using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _manager;
        private readonly IWorkCategoryService _workCategoryManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioController(IPortfolioService manager, IWorkCategoryService workCategoryManager, IWebHostEnvironment webHostEnvironment)
        {
            _manager = manager;
            _workCategoryManager = workCategoryManager;
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
            var workCategoryData = _workCategoryManager.GetAll().Data;

            if (workCategoryData.Count != 0)
            {
                ViewData["WorkCategories"] = new SelectList(workCategoryData, "ID", "Name");
            }
            else
            {
                TempData["AlertMessage"] = "Firstly you must add some work category";
                return Redirect("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfoli entity)
        {
            string fileName = Uploader(entity, "WorkImage", entity.WorkImageFile);

            var result = _manager.Add(entity, fileName);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var workCategoryData = _workCategoryManager.GetAll().Data;

                ViewData["WorkCategories"] = new SelectList(workCategoryData, "ID", "Name");
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
            var workCategoryData = _workCategoryManager.GetAll().Data;

            if (workCategoryData != null)
            {
                ViewData["WorkCategories"] = new SelectList(workCategoryData, "ID", "Name");
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
        public IActionResult Edit(Portfoli person)
        {
            var existingPortfolio = _manager.GetByID(person.ID).Data;

            string fileName = person.WorkImageFile != null ? Uploader(person, "WorkImage", person.WorkImageFile)
                                                       : existingPortfolio.WorkImgPath;

            var result = _manager.Update(person, fileName);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var workCategoryData = _workCategoryManager.GetAll().Data;

                ViewData["WorkCategories"] = new SelectList(workCategoryData, "ID", "Name");
                foreach (var error in result.MessageList)
                {
                    ModelState.Remove(result.Data[result.MessageList.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.MessageList.IndexOf(error)], error);
                }
                return View(person);
            }

        }

        private string Uploader(Portfoli entity, string property, IFormFile document)
        {
            if (document != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string folder = property + "/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                entity.WorkImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}
