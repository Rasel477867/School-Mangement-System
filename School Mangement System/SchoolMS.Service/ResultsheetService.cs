using SchoolMS.Core.Models;
using SchoolMS.Repository.Contacts;
using SchoolMS.Repository.Core;
using SchoolMS.Service.Contacts;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service
{
    public class ResultsheetService : Service<Resultsheet>, IResultsheetService
    {
        private readonly IResultsheetRepository _resultsheetRepository;
        public ResultsheetService(IResultsheetRepository repository) : base(repository)
        {
            _resultsheetRepository = repository;
        }

        public async Task<bool> AddResultSheetAsync(List<Resultsheet> resultSheets)
        {
            for(int i=0; i<resultSheets.Count(); i++)
            {
                int mark = resultSheets[i].Marks;
                if (mark >= 80)
                    resultSheets[i].Term = "A+";
                else if (mark >= 75)
                    resultSheets[i].Term = "A";
                else if (mark >= 70)
                    resultSheets[i].Term = "A-";
                else if (mark >= 65)
                    resultSheets[i].Term = "B+";
                else if (mark >= 60)
                    resultSheets[i].Term = "B";
                else if (mark >= 55)
                    resultSheets[i].Term = "B-";
                else if (mark >= 50)
                    resultSheets[i].Term = "C";
                else if(mark >=45)
                    resultSheets[i].Term = "C-";
                else if(mark >=40)
                    resultSheets[i].Term = "D";
                else if(mark>=33)
                    resultSheets[i].Term = "D-";
                else
                    resultSheets[i].Term= "F";

            }
          return  await _resultsheetRepository.MultipleResultAdd(resultSheets);

        }

        public async Task<List<Resultsheet>> StudnetResultGetbyClassId(int classId, int studentId)
        {
            return await _resultsheetRepository.StudnetResultGetbyClassId(classId, studentId);
        }
    }
}
