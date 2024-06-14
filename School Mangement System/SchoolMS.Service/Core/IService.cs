using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Core
{
    public interface IService<T> where T : class
    {
        Task Add(T Entity);
        Task Delete(T Entity);
        
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T Entity);
    }
}
