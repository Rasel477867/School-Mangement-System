using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassLevelService _classLevelService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IClassLevelService classLevelService, IMapper mapper)
        {
            _studentService = studentService;
            _classLevelService = classLevelService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var model = await _studentService.GetAll();
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = new StudentView();
            model.ClassList= _classLevelService.GetAll().Result.Select(c=>new SelectListItem
            {
                Text= c.Name,
                Value=c.Id.ToString()
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentView student)
        {
            if(ModelState.IsValid)
            {
                var model = _mapper.Map<Student>(student);
                await _studentService.Add(model);
                return RedirectToAction("Index");

            }
            return View(student);
        }
        public async Task<IActionResult> Details(int id)
        {
            var Student=await _studentService.GetById(id);
            if (Student == null)
                return null;
            else
            {
                return PartialView("_StudentDetails", Student);
            }
           
        }
    }
}
