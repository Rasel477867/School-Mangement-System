using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMS.Web.ViewModels
{
    public class TeacherView
    {
        [Required]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        public string Phone { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public int DesignationId { get; set; }
        [Required]
        public int ClassId { get; set; }
        public List<SelectListItem> ?DesignationList { get; set; }
        public List<SelectListItem> ? ClassList { get; set; }
    
    }
}
