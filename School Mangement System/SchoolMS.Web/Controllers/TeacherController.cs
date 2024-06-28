using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;
using System.Security.Cryptography.Xml;

namespace SchoolMS.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IDesignationService _designationService;
        private readonly IClassLevelService _classLevelService;

        public TeacherController(ITeacherService teacherService, IMapper mapper,IDesignationService designationService, IClassLevelService classLevelService)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _designationService = designationService;
            _classLevelService = classLevelService;
        }
        public async Task<IActionResult> Index()
        {
            var model=await _teacherService.GetAll();

            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = new TeacherView();
            model.DesignationList = _designationService.GetAll().Result.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value=c.Id.ToString(),

            }).ToList(); 
            model.ClassList = _classLevelService.GetAll().Result.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value=c.Id.ToString(),

            }).ToList();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherView model)
        {
            if (ModelState.IsValid)
            {
                var obj = _mapper.Map<Teacher>(model);
               await _teacherService.Add(obj);
                TempData["Add"] = "Inserted Successfully ";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorAdd"] = "Not Inserted Data";
                return View(model);
            }
            

        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _teacherService.GetById(id);
            if (model != null)
            {
                return PartialView("_TeacherDetails", model);
            }
            return null;
        }
    }
}
