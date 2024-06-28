using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFCoreDBContext dbContext;
        private IDbContextTransaction _transaction;

        private GenericRepository<Order> orderRepo;
        private GenericRepository<OrderItem> orderItemRepo;

        public UnitOfWork(EFCoreDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public GenericRepository<Order> OrderRepo
        {
            get
            {
                if(orderRepo == null)
                {
                    orderRepo =  new GenericRepository<Order>(dbContext);
                }
                return orderRepo;
            }
        }

        public GenericRepository<OrderItem> OrderItemRepo
        {
            get
            {
                if (orderItemRepo == null)
                {
                    orderItemRepo = new GenericRepository<OrderItem>(dbContext);
                }
                return orderItemRepo;
            }
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction has begun.");
            }
            try
            {
                // 提交事务  
                _transaction.Commit();
            }
            finally
            {
                // 释放事务资源  
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already begun.");
            }

            _transaction = dbContext.Database.BeginTransaction();

        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction has begun.");
            }

            // 回滚事务  
            _transaction.Rollback();

            // 释放事务资源  
            _transaction.Dispose();

            _transaction = null;

        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // 确保事务被回滚（如果有的话）  
                    if (_transaction != null)
                    {
                        _transaction.Rollback();
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
