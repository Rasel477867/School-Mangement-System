using SchoolMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Service.Core
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public  Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task Add(T Entity)
        {
          await  _repository.Add(Entity);
        }

        public virtual async Task Delete(T Entity)
        {
           await _repository.Delete(Entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {

           return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(int id)
        { 
            T obj=await _repository.GetById(id);
            return obj;
        }

        public virtual async Task Update(T Entity)
        {
            await  _repository.Update(Entity);
        }
    }
}
