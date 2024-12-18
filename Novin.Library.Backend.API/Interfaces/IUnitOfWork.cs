using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Thing;
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        Task<int> SaveAsync();
    }
}