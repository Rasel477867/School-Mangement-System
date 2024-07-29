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
    public class ResultsheetRepository : Repository<Resultsheet>, IResultsheetRepository
    {
        private readonly ApplicationDbContext _db;
        public ResultsheetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> MultipleResultAdd(List<Resultsheet> results)
        {
            for(int i=0; i<results.Count(); i++)
            {
                var result =await _db.ResultsSheets.Where(x=>x.ClassId == results[i].ClassId && x.SubjectId == results[i].SubjectId && x.StudentId == results[i].StudentId).ToListAsync();
                if(result.Count()>0)
                {

                    await Task.Run(() =>
                    {
                        _db.ResultsSheets.Remove(result[0]);

                    });    
                }
            
            await  _db.ResultsSheets.AddAsync(results[i]);
            }

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Resultsheet>> StudnetResultGetbyClassId(int classId, int studentId)
        {
            return await _db.ResultsSheets.Where(x=>x.ClassId==classId && x.StudentId==studentId).ToListAsync();
        }
    }
}
