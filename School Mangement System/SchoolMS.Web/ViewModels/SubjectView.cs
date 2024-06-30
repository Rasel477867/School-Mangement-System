using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Web.ViewModels
{
    public class SubjectView

    {
        [Required]
        [Display(Name="Subject Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Subject Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name="Class Id")]
        public int ClassId { get; set; }
    }
}
