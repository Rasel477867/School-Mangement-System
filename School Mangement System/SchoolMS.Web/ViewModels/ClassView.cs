using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolMS.Web.ViewModels
{
    public class ClassView
    {
        public int ClassId { get; set; }
        public List<SelectListItem>? ClassList { get; set; }
    }
}
