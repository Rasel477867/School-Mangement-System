using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;
using System.Drawing;

namespace SchoolMS.Web.Controllers
{
    public class AttendenceController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly IAttendenceService _attendenceService;
        public AttendenceController(IClassLevelService classLevelService, ISubjectService subjectService,IStudentService studentService,IAttendenceService attendenceService)
        {
            _classLevelService = classLevelService;
            _subjectService = subjectService;
            _studentService = studentService;
            _attendenceService = attendenceService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var model = new ClassSubjectView();
            model.ClassLists=_classLevelService.GetAll().Result.Select(x=>new SelectListItem
            {
                Value=x.Id.ToString(),
                Text=x.Name
            }).ToList();

            return View(model);
        }
      
        public async Task<IActionResult>GetSubject(int id)
        {
            var model = await _subjectService.GetSubjectsByClassId(id);
            return Json(model);
        } 
        public async Task<IActionResult>GetStudent(int id)
        {
            var model = await _studentService.GetStudentsByClassId(id);
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAttendence(ClassSubjectView model)
        {
            if(ModelState.IsValid)
            {
                var modelAttendence = new List<AttendenceView>();
                var students = await _studentService.GetStudentsByClassId(model.ClassId);
          
                modelAttendence=students.Select(x=>new AttendenceView
                {
                    Id=x.Id,
                    Name=x.Name,
                    SubjectId=model.SubjectId
                  
                }).ToList();
                return View(modelAttendence);
            }
            TempData["Error"] = "Your Subject or Class Is Invalid";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AttendenceCreate(List<AttendenceView> attendences)
        {
         
            var model = new List<Attendence>();
            model=attendences.Select(x=>new Attendence
            {
                Date=x.Date,
                IsPresent=x.IsPresent,
                SubjectId = x.SubjectId,
                StudentId=x.Id

            }).ToList();
            var state= await _attendenceService.AddMulltipleAttendence(model);

            if (state)
            {
                TempData["ASuccess"] = "Attendence Successfully Store";
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateStudentAttendence()
        {
            var model = new ClassStudentView();
            model.ClassLists = _classLevelService.GetAll().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> StudentAttendenceResult(ClassStudentView classStudent)
        {

            return View(classStudent);
        }
    }
}
