using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMS.Core.Models.Core;

namespace SchoolMS.Core.Models
{
    public class Teacher:BaseEntity
    {
        [Display(Name ="Teacher Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name="Phone Number")]
        public string Phone {  get; set; }
        public int Salary {  get; set; }
        public String Address { get; set; }
        public int DesignationId {  get; set; }
        [ForeignKey(nameof(DesignationId))]
        public Designation Designation { get; set; }
        public int ClassId {  get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassLevel ClassLevel { get; set; }
        

    }

  
}
