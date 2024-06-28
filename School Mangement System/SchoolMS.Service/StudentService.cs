using SchoolMS.Core.Models;
using SchoolMS.Repository.Contacts;
using SchoolMS.Repository.Core;
using SchoolMS.Service.Contacts;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository repository) : base(repository)
        {
            _studentRepository = repository;
        }

        public async Task<List<Student>> Studentdetails(int id)
        {
           return await _studentRepository.Studentdetails(id);
        }
    }
}
