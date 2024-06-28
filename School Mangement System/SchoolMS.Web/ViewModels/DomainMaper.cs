using AutoMapper;
using SchoolMS.Core.Models;

namespace SchoolMS.Web.ViewModels
{
    public class DomainMaper:Profile
    {
        public DomainMaper()
        {
            CreateMap<DesignationView, Designation>();
            CreateMap<Designation,DesignationView>();
            CreateMap<ClassLevel, ClassLevelView>();
            CreateMap<ClassLevelView,ClassLevel>();
            CreateMap<Teacher, TeacherView>();
            CreateMap<TeacherView, Teacher>();
            CreateMap<StudentView, Student>();
            CreateMap<Student, StudentView>();



            
        }
    }
}
