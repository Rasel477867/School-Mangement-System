using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Web.ViewModels
{
    public class StudentAttendenceView
    {
        public int Serial { get; set; }
        public int StudentId { get; set;}
        public string StudentName { get; set; }
        [Display (Name ="Subject Id")]
        public int SubjectId { get; set; }
        [Display (Name ="Subject Name")]
        public string SubjectName { get; set; }
        [Display (Name ="Total ")]
        public int TotalAttendence {  get; set; }
        [Display(Name ="Attendence(%)")]
        public float Attendence { get; set; }
    }
}
