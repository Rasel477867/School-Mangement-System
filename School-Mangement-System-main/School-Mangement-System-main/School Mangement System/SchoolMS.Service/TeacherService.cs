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
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Teacher>> TeacherDetails(int id)
        {
          return await _repository.TeacherDetails(id);
        }
    }
}
