using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolMS.Web.ViewModels
{
    public class ClassSubjectView
    {
        public int ClassId {  get; set; }
        public List<SelectListItem> ?ClassLists { get; set; }
        public int SubjectId {  get; set; }
        public List<SelectListItem> ?SubjectLists { get; set; }
    }
}
