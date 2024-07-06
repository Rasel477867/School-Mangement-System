using System.ComponentModel.DataAnnotations.Schema;
using SchoolMS.Core.Models.Core;

namespace SchoolMS.Core.Models
{
    public class Subject:BaseEntity
    {
        public string  Name { get; set; }
        public string Code { get; set; }
        public int ClassId {  get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassLevel ClassLevel { get; set; }
   
        public ResultSheet ResultSheet { get; set; }
    }
}