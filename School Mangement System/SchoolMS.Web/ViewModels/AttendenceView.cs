using SchoolMS.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMS.Web.ViewModels
{
    public class AttendenceView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public int SubjectId { get; set; }
        public AttendenceView()
        {
            this.Date= DateTime.Now;
            this.IsPresent = true;
        }

    }
}
