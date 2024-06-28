using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Web.ViewModels
{
    public class StudentView
    {
        [Required]
        [Display(Name="Student Name")]
        public string Name { get; set; }
        [Required]
       
        public int Age { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        public String Phone { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name ="Class Name")]
        public int ClassId { get; set; }
        public List<SelectListItem>? ClassList { get; set; }
    }
}
