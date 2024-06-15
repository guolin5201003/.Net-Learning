using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        T Get(long id);
        IEnumerable<T> GetAll();

    }
}
