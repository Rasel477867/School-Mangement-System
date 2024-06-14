using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using SchoolMS.Core.Models.Core;

namespace SchoolMS.Core.Models
{
    public class Student:BaseEntity
    {
        public string  Name { get; set; }
        public int Age { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassLevel ClassLevel { get; set; }
       
        public ResultSheet ResultSheet { get; set; }
  
        public Attendence Attendence { get; set; }



    }
}