using SchoolMS.Core.Models;
using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository.Contacts
{
    public interface IResultsheetRepository:IRepository<Resultsheet>
    {
       public Task<bool> MultipleResultAdd(List<Resultsheet> results);
        public Task<List<Resultsheet>> StudnetResultGetbyClassId(int classId, int studentId);
    }
}
