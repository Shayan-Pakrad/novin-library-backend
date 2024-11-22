using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities.Base;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDB _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(LibraryDB db, IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Thing
        {
           return (IRepository<TEntity>)_serviceProvider.GetServices(typeof(IRepository<TEntity>));
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}