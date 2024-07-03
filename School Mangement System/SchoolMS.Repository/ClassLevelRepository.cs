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
    public class ClassLevelRepository : Repository<ClassLevel>, IClassLevelRepository
    {
        private readonly ApplicationDbContext _db;
        public ClassLevelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool AddValidation(string name)
        {
            var obj=  _db.ClassLevels.Where(c => c.Name.ToLower() == name.ToLower());
            if (obj.Count()>0)
            {
                return false;
            }
           else 
                return true;
        }
    }
}
