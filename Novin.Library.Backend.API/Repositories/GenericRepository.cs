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
        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            Save();
        }
        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            Save();
        }
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            Save();
        }
        public virtual TEntity? GetByGuid(string guid)
        {
            return _dbSet.FirstOrDefault(m => m.Guid == guid);
        }
        public virtual TEntity? GetById(int id)
        {
            return _dbSet.FirstOrDefault(m => m.Id == id);
        }
        public virtual void Save()
        {
            _unitOfWork.Save();
        }
    }
}