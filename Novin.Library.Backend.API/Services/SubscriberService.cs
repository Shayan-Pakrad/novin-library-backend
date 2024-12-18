using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Mappers;

namespace Novin.Library.Backend.API.Services
{
    public class SubscriberService : IService<Subscriber, SubscriberDto, SubscriberAddOrUpdateDto>
    {
        private readonly IRepository<Subscriber> _subscribers;

        public SubscriberService(IRepository<Subscriber> subscribers)
        {
            _subscribers = subscribers;
        }

        public async Task<IEnumerable<SubscriberDto>> ListAsync()
        {
            return await _subscribers.GetAll()
            .Select(s => s.ToSubscriberDto())
            .ToListAsync();
        }

        public async Task<int> AddAsync(SubscriberAddOrUpdateDto entity)
        {
            var s = entity.ToSubscriberFromSubscriberDto();
            return await _subscribers.AddAsync(s);
        }

        public async Task<int> UpdateAsync(string guid, SubscriberAddOrUpdateDto entity)
        {
            var dbSub = await _subscribers.GetByGuidAsync(guid);
            if (dbSub != null)
            {
                dbSub.Address = entity.Address;
                dbSub.Fullname = entity.Fullname;
                dbSub.PhoneNumber = entity.PhoneNumber;
                return await _subscribers.UpdateAsync(dbSub);
            }
            return 0;
        }
        
        public async Task<int> RemoveAsync(string guid)
        {
            var dbSub = await _subscribers.GetByGuidAsync(guid);
            if (dbSub != null)
            {
                return await _subscribers.RemoveAsync(dbSub);
            }
            return 0;
        }
    }
}