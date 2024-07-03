using SchoolMS.Core.Models;
using SchoolMS.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Contacts
{
    public interface IClassLevelService:IService<ClassLevel>  
    {
        public bool AddValidation(string name);
    }
}
