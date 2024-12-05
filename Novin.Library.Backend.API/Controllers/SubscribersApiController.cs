using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Novin.Library.Backend.API.Controllers.Base;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Services;

namespace Novin.Library.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscribersApiController : BaseApiController<SubscriberService, Subscriber, SubscriberDto, SubscriberAddOrUpdateDto>
    {
        public SubscribersApiController(SubscriberService service) : base(service)
        {
        }
    }
}