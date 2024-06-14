using Azure.Identity;
using SchoolMS.Core.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMS.Core.Models
{
    public class ClassLevel:BaseEntity
    {
        [Display(Name="Class Name")]
        public String  Name { get; set; }
        [Display(Name ="Room Number")]
        public int RoomNumber { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Subject>Subjects { get; set; }
        public List<Student> Students { get; set; }
       
        public ResultSheet ResultSheet { get; set; }
    }
}