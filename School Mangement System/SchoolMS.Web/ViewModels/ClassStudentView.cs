using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolMS.Web.ViewModels
{
    public class ClassStudentView
    {
        public int ClassId { get; set; }
        public List<SelectListItem>? ClassLists { get; set; }
        public int StudentId { get; set; }
        public List<SelectListItem>? StudentLists { get; set; }
    }
}
