using SchoolMS.Core.Models;
using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository.Contacts
{
    public interface IStudentRepository:IRepository<Student>
    {
       public Task<List<Student>>Studentdetails(int id);
        public Task<List<Student>> GetStudentsByClassId(int id);
    }
}
