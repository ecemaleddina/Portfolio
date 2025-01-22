using Business.Abstract;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly IServiceService _serviceService;
        private readonly IExperienceService _experinceService;
        private readonly IAboutSkillService _aboutSkillService;
        private readonly IPortfolioService _portfolioService;
        private readonly IPositionService _positionService;
        private readonly ISkillService _skillService;
        private readonly IWorkCategoryService _workCategoryService;
        public HomeController(ILogger<HomeController> logger, IPersonService personService, IServiceService serviceService, IExperienceService experinceService, IAboutSkillService aboutSkillService, IPortfolioService portfolioService, IPositionService positionService, ISkillService skillService, IWorkCategoryService workCategoryService)
        {
            _logger = logger;
            _personService = personService;
            _serviceService = serviceService;
            _experinceService = experinceService;
            _aboutSkillService = aboutSkillService;
            _portfolioService = portfolioService;
            _positionService = positionService;
            _skillService = skillService;
            _workCategoryService = workCategoryService;
        }

        public IActionResult Index()
        {
            var dataService = _serviceService.GetAll().Data;
            var dataPerson = _personService.GetAll().Data[0];
            var dataexperince = _experinceService.GetAll().Data;
            var dataAbouskill = _aboutSkillService.GetAll().Data;
            var dataPortfoli = _portfolioService.GetAll().Data;
            var datapositions = _positionService.GetAll().Data;
            var dataSkills = _skillService.GetAll().Data;
            var dataWorkCategories = _workCategoryService.GetAll().Data;
            HomeViewModel homeViewModel = new()
            {
                Services = dataService,
                Person = dataPerson,
                Experiences = dataexperince,
                AboutSkills = dataAbouskill,
                Portfolios = dataPortfoli,
                Positions = datapositions,
                Skills = dataSkills,
                WorkCategories = dataWorkCategories,
            };

            return View(homeViewModel);
        }


    }
}