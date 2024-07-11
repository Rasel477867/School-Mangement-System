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
    public class AttendenceService : Service<Attendence>, IAttendenceService
    {
        private readonly IAttendenceRepository _attendenceRepository;
        public AttendenceService(IAttendenceRepository repository) : base(repository)
        {
            _attendenceRepository = repository;
        }

        public async Task<bool> AddMulltipleAttendence(List<Attendence> mulltipleAttences)
        {
            return await _attendenceRepository.AddMulltipleAttendence(mulltipleAttences);
            
        }
    }
}
