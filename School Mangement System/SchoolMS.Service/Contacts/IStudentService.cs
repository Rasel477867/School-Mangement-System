using SchoolMS.Core.Models;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Contacts
{
    public interface IStudentService:IService<Student>
    {
        public Task<List<Student>> Studentdetails(int id);
        public Task<List<Student>> GetStudentsByClassId(int id);
    }
}
