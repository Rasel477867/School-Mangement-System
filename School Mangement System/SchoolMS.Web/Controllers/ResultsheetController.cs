using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class ResultsheetController : Controller
    {
        private readonly IResultsheetService _resultsheetService;
        private readonly IClassLevelService _classLevelService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        public ResultsheetController(IResultsheetService resultsheetService, IClassLevelService classLevelService,IStudentService studentService,ISubjectService subjectService)
        {
            _resultsheetService = resultsheetService;
            _classLevelService = classLevelService;
            _studentService = studentService;
            _subjectService = subjectService;
        }
        public async Task<IActionResult> CreateStudentResult()
        {
            var model = new ClassStudentView();
            model.ClassLists = _classLevelService.GetAll().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(model);
        }     
        public async Task<IActionResult> ShowStudentResult()
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
        public async Task<IActionResult> CreateResult(ClassStudentView classStudent)
        {
            var SubjectList=new List<ResultView>();
            var subject = await _subjectService.SubjectListDetails(classStudent.ClassId);
            var Class=await _classLevelService.GetById(classStudent.ClassId);
            var Student = await _studentService.GetById(classStudent.StudentId);
            for(int i=0; i<subject.Count(); i++)
            {
                var result = new ResultView();
                result.SubjectName= subject[i].Name;
                result.StudentId = classStudent.StudentId;
                result.SubjectId = subject[i].Id;
                result.ClassId= classStudent.ClassId;
                result.StudentName =Student.Name;
                result.ClassName= Class.Name;
                result.Serial = i + 1;

                SubjectList.Add(result);
            }
            return View(SubjectList);
        }
        [HttpPost]
        public async Task<IActionResult> Create(List<ResultView> resultList)
        {
            if(ModelState.IsValid)
            {
                var resultSheet = new List<Resultsheet>();
                resultSheet = resultList.Select(result => new Resultsheet
                {
                    Marks = result.Marks,
                    StudentId = result.StudentId,
                    SubjectId = result.SubjectId,
                    ClassId = result.ClassId,

                }).ToList();
                var state=await _resultsheetService.AddResultSheetAsync(resultSheet);
            }
            return RedirectToAction("ShowStudentResult");
        }
        [HttpPost]
        public async Task<IActionResult> ShowResult(ClassStudentView classStudent)
        {
            var subjectlist = await _resultsheetService.StudnetResultGetbyClassId(classStudent.ClassId, classStudent.StudentId);
            int i = 0;
            var Class = await _classLevelService.GetById(classStudent.ClassId);
            var Student= await _studentService.GetById(classStudent.StudentId);
      
            var Resultlist = subjectlist.Select(x => new ResultView
            {
                StudentId = x.StudentId,
                ClassId = x.ClassId,
                SubjectId = x.SubjectId,
                Grade = x.Term,
                Marks=x.Marks,
                ClassName=Class.Name,
                StudentName=Student.Name,
              


            }).ToList();
            for(i=0; i<Resultlist.Count(); i++)
            {
                var Subject = await _subjectService.GetById(subjectlist[i].SubjectId);
                Resultlist[i].SubjectName = Subject.Name;
                Resultlist[i].Serial = i + 1;

            }
            return View(Resultlist);
        }
    }
}
