using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMS.Core.Models;
using SchoolMS.Repository.Contacts;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class ClassLevelController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly IMapper _mapper;

        public ClassLevelController(IClassLevelService classLevelService,IMapper mapper)
        {
                _classLevelService = classLevelService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model=await _classLevelService.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClassLevelView model)
        {
            if (ModelState.IsValid)
            {
                var obj = _mapper.Map<ClassLevel>(model);
               await _classLevelService.Add(obj);
                TempData["Success"] = "Inserted Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Invalid Insert";
            return View(model);
        }
    }
}
