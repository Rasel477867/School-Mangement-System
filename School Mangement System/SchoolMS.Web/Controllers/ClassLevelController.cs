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
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public ClassLevelController(IClassLevelService classLevelService,IMapper mapper,ITeacherService teacherService, IStudentService studentService)
        {
             _classLevelService = classLevelService;
            _mapper = mapper;
            _teacherService = teacherService;
            _studentService = studentService;
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
                var state = _classLevelService.AddValidation(obj.Name);
                if(state)
                {
                    await _classLevelService.Add(obj);
                    TempData["Success"] = "Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AddD"] = "Duplicate data added";
                    return View();
                }
             
            }
            TempData["Error"] = "Invalid Insert";
            return View(model);
        }
        public async Task<IActionResult> TeacherDetails(int id)
        {
            var model=await _teacherService.TeacherDetails(id);
           

            return View(model);
        }
        public async Task<IActionResult>StudentDetails(int id)
        {
            var model=await _studentService.Studentdetails(id);
            return View(model);
        }
    }
}
