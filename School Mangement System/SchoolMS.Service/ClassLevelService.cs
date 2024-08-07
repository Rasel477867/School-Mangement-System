﻿using SchoolMS.Core.Models;
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
    public class ClassLevelService : Service<ClassLevel>, IClassLevelService
    {
        private readonly IClassLevelRepository _classLevelRepository;
        public ClassLevelService(IClassLevelRepository repository) : base(repository)
        {
            _classLevelRepository = repository;
        }

        public bool AddValidation(string name)
        {
           return _classLevelRepository.AddValidation(name);
        }
    }
}
