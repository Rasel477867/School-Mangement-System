using SchoolMS.Core.Models;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Contacts
{
    public interface IResultsheetService:IService<Resultsheet>
    {
        public Task<bool> AddResultSheetAsync(List<Resultsheet> resultSheets);
        public Task<List<Resultsheet>> StudnetResultGetbyClassId(int classId, int studentId);
    }
}
