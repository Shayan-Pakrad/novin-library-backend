using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities.Base;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Thing
    {

        // Class properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<TEntity> _dbSet;

        // Class ctor
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.GetDbSet<TEntity>();
        }

        // Class method implementations
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsync();
        }
        public virtual async Task<int> RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync();
        }
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveAsync();
        }
        public virtual async Task<TEntity?> GetByGuidAsync(string guid)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Guid == guid);
        }
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }
        public virtual async Task<int> SaveAsync()
        {
            return await _unitOfWork.SaveAsync();
        }
    }
}