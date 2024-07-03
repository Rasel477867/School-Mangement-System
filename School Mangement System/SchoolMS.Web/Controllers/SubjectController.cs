using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IClassLevelService _classLevelService;
        public SubjectController(ISubjectService subjectService, IClassLevelService classLevelService)
        {
            _subjectService = subjectService;
            _classLevelService = classLevelService; 

        }
        public async Task<IActionResult> Index()
        {
            var obj = new ClassView();
            obj.ClassList= _classLevelService.GetAll().Result.Select(x=>new SelectListItem
            {
                Value=x.Id.ToString(),
                Text=x.Name
            }).ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Create(ClassView obj)
        {
            if (obj.ClassId == 0)
            {
                TempData["InsertError"] = "Select YOUR CLASS";
                return RedirectToAction("Index");
            }
               
            var model = new Subjects();
            model.ListSubjects = new List<SubjectView>();
            var subjectview = new SubjectView()
            {
                ClassId = obj.ClassId
            };
            model.ListSubjects.Add(subjectview);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>CreateSubject(Subjects subjects)
        {
           
            int y = 0;
            var model = new List<Subject>();
           foreach (var subject in subjects.ListSubjects) {
            var obj=new Subject();
                
                obj.Name= subject.Name;
                obj.Code= subject.Code;
                obj.ClassId= subject.ClassId;
                var state = _subjectService.AddValidation(obj);
                if(state)
                {
                    model.Add(obj);
                }
                else
                {
                    y = 1;
                }
            
            }
           if(model.Count>0)
            {
                if (y == 1)
                {
                    TempData["Success"] = "Subject Inserted but duplicate Subject Not Added";
                }
                else
                {
                    TempData["Success"] = "Data Inserted Successfully";
                }
                await _subjectService.MultipleSubjectAdd(model);
            }
            else
            {
                TempData["Error"] = " Invalid Subject";
            }
         

           return RedirectToAction("Index");
        }
      

    }
}
