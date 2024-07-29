using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Web.ViewModels
{
    public class ResultView
    {
        public int? Serial { get; set; }
        public string? ClassName { get; set; }
        public string? StudentName { get; set; }
        public int StudentId { get; set; }
        [Display(Name ="Subject Name")]
        public string? SubjectName {  get; set; }
        public int Marks {  get; set; }
        public int ClassId {  get; set; }
        public int SubjectId {  get; set; }
        public string? Grade {  get; set; }
        
    }
}
