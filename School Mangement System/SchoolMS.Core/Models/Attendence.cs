using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMS.Core.Models.Core;

namespace SchoolMS.Core.Models
{
    public class Attendence:BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        [ForeignKey(nameof(StudentId))]
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
