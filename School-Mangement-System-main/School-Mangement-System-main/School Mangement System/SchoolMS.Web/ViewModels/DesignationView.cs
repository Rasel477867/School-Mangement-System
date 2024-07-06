using SchoolMS.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Web.ViewModels
{
    public class DesignationView
    {
        [Required]
        [Display(Name ="Teacher Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Teacher Level")]
        public string Description { get; set; }
        
    }
}
