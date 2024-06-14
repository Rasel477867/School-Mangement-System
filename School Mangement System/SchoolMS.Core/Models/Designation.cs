using SchoolMS.Core.Models.Core;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Core.Models
{
    public class Designation:BaseEntity
    {
        [Display(Name="Teacher Title")]
        public string? Title { get; set; }
        [Display(Name ="Teacher Level")]
        public string?  Description { get; set; }
        public List<Teacher>? Teachers { get; set; }

    }
}