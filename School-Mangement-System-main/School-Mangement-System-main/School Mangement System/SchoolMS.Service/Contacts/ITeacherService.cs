﻿using SchoolMS.Core.Models;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Contacts
{
    public interface ITeacherService:IService<Teacher>
    {
        public Task<List<Teacher>> TeacherDetails(int id);
    }
}
