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
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _db;
        public SubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public  bool AddValidation(Subject subject)
        {
            foreach(var obj in _db.Subjects)
            {
                if(obj.ClassId ==subject.ClassId && obj.Name==subject.Name) 
                       return false;
            }
            return true;
            
        }

        public async Task MultipleSubjectAdd(List<Subject> subjects)
       {
            _db.Subjects.AddRange(subjects);
         await _db.SaveChangesAsync();
            //foreach (Subject obj in subjects)
            // {
            //     _db.Subjects.Add(obj);
            //     await _db.SaveChangesAsync();
            // }
    
       }
    }
}
