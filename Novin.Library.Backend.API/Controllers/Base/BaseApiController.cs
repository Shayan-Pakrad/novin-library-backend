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
        public virtual IResult List() {
            return Results.Ok(_service.List());
        }

        [HttpPost("add")]
        public virtual void Add(TAddOrUpdateDto entity) {
            _service.Add(entity);
        }

        [HttpPut("update/{guid}")]
        public virtual void Update(string guid, TAddOrUpdateDto entity) {
            _service.Update(guid, entity);
        }

        [HttpDelete("delete/{guid}")]
        public virtual void Delete(string guid) {
            _service.Remove(guid);
        }
    }
}