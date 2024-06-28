using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    }
}
