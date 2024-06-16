using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture;
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly EFCoreDBContext dbContext;
    private readonly DbSet<T> dbSet;

    public GenericRepository(EFCoreDBContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<T>();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public T AddToDB(T entity)
    {
        dbSet.Add(entity);
        dbContext.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        if (dbContext.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }
        dbSet.Remove(entity);
    }

    public T Get(long id)
    {
        return dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public void Update(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
    }

    public int UpdateToDB(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        return dbContext.SaveChanges() ;
    }
    public int DeleteToDB(T entity)
    {
        if (dbContext.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }
        dbSet.Remove(entity);
        return dbContext.SaveChanges();
    }

}
