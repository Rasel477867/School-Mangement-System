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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Teacher>> TeacherDetails(int id)
        {
            return await _db.Teachers.Where(c => c.ClassId==id).ToListAsync();
        }
    }
}
