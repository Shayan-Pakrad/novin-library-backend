using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Interfaces
{
    public interface IService<TEntity, TEntityDto, TAddOrUpdateDto> where TEntity : Thing
    {
        IEnumerable<TEntityDto> List();
        void Add(TAddOrUpdateDto entity);
        void Update(string guid, TAddOrUpdateDto entity);
        void Remove(string guid);
    }
}