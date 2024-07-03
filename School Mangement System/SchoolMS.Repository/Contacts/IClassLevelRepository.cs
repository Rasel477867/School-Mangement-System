using SchoolMS.Core.Models;
using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Repository.Contacts
{
    public interface IClassLevelRepository:IRepository<ClassLevel>
    {
        public bool AddValidation(string name);
    }
}
