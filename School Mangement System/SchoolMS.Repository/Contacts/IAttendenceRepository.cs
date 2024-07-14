using SchoolMS.Core.Models;
using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository.Contacts
{
   public interface IAttendenceRepository:IRepository<Attendence>
    {
        public Task<bool>AddMulltipleAttendence(List<Attendence> mulltipleAttences);
        public Task<float> AttendenceCalculationBySubject(int SubjectId, int StudentId);
        public Task<List<Attendence>> GetAttendencesBySubject(int SubjectId, int StudentId);
    }
}
