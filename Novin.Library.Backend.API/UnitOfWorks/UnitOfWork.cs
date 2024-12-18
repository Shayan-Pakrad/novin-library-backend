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
            var result = _serviceProvider.GetServices(typeof(IRepository<TEntity>));
            if (result != null){
                return (IRepository<TEntity>)result;
            }
            throw new Exception("Unknown Service");
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}