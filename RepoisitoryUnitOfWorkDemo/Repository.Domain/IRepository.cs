using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(long id);
        IEnumerable<T> GetAll();
        T Get(long id, params string[] includesProperties);

        T AddToDB(T entity);
        int DeleteToDB(T entity);
        int UpdateToDB(T entity);
    }
}
