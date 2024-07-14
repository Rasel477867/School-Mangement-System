using Microsoft.EntityFrameworkCore;
using SchoolMS.Core.Models;
using SchoolMS.Repository.Contacts;
using SchoolMS.Repository.Core;
using SchoolMS.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository
{
    public class AttendenceRepository : Repository<Attendence>, IAttendenceRepository
    {
        private readonly ApplicationDbContext _db;
        public AttendenceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> AddMulltipleAttendence(List<Attendence> mulltipleAttences)
        {
            await _db.Attenants.AddRangeAsync(mulltipleAttences);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<float> AttendenceCalculationBySubject(int SubjectId, int StudentId)
        {
            float total= _db.Attenants.Where(x=>x.SubjectId==SubjectId &&  x.StudentId==StudentId).Count();
            float present=_db.Attenants.Where(x=>x.SubjectId==SubjectId && x.StudentId==StudentId && x.IsPresent).Count();
            return ((present / total) * (100));

        }

        public async Task<List<Attendence>> GetAttendencesBySubject(int SubjectId, int StudentId)
        {
            return await _db.Attenants.Where(x=>x.SubjectId==SubjectId && x.StudentId==StudentId).ToListAsync();
        }
    }
}
