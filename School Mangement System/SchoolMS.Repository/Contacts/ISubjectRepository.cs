﻿using SchoolMS.Core.Models;
using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository.Contacts
{
  public interface ISubjectRepository: IRepository<Subject>
    {
        public Task MultipleSubjectAdd(List<Subject> subject);
        public bool AddValidation(Subject subject);
    }
}
