using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using SchoolMS.Core.Models.Core;

namespace SchoolMS.Core.Models
{
    public class ResultSheet:BaseEntity
    {
        public int Marks { get; set; }
        public string Term { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }
        public int StudentId  { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassLevel ClassLevel { get; set; }
       
      
    }
}