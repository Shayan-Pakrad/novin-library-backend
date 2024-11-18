using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Thing
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity? GetById(int id);
        TEntity? GetByGuid(string guid);
        void Save();

    }
}