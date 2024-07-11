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
    public class SubjectService : Service<Subject>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository repository) : base(repository)
        {
            _subjectRepository = repository;
        }

        public bool AddValidation(Subject subject)
        {
            return _subjectRepository.AddValidation(subject);
        }

        public async Task<List<Subject>> GetSubjectsByClassId(int id)
        {
           return await _subjectRepository.GetSubjectsByClassId(id);
        }

        public async Task MultipleSubjectAdd(List<Subject> subject)
        {
            await _subjectRepository.MultipleSubjectAdd(subject);
        }

        public async Task<List<Subject>> SubjectListDetails(int id)
        {
            return await _subjectRepository.SubjectListDetails(id);
        }
    }
}
