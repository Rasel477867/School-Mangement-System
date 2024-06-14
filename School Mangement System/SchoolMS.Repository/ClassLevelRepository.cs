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
        public ClassLevelRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
