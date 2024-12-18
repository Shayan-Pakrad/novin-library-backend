using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Novin.Library.Backend.API.Entities.Base;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Controllers.Base
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class BaseApiController<TService, TEntity, TEntityDto, TAddOrUpdateDto> : ControllerBase
    where TService : IService<TEntity, TEntityDto, TAddOrUpdateDto>
    where TEntity : Thing
    {
        protected readonly TService _service;

        public BaseApiController(TService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public virtual async Task<IResult> ListAsync() {
            return Results.Ok(await _service.ListAsync());
        }

        [HttpPost("add")]
        public virtual async Task<int> AddAsync(TAddOrUpdateDto entity) {
            return await _service.AddAsync(entity);
        }

        [HttpPut("update/{guid}")]
        public virtual async Task<int> UpdateAsync(string guid, TAddOrUpdateDto entity) {
            return await _service.UpdateAsync(guid, entity);
        }

        [HttpDelete("delete/{guid}")]
        public virtual async Task<int> DeleteAsync(string guid) {
            return await _service.RemoveAsync(guid);
        }
    }
}