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
    }
}
