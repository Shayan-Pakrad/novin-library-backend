using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Interfaces
{
    public interface IService<TEntity, TEntityDto, TAddOrUpdateDto> where TEntity : Thing
    {
        Task<IEnumerable<TEntityDto>> ListAsync();
        Task<int> AddAsync(TAddOrUpdateDto entity);
        Task<int> UpdateAsync(string guid, TAddOrUpdateDto entity);
        Task<int> RemoveAsync(string guid);
    }
}