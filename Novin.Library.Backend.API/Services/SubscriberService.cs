using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<SubscriberDto> List()
        {
            return _subscribers.GetAll()
            .Select(s => s.ToSubscriberDto())
            .ToList();
        }

        public void Add(SubscriberAddOrUpdateDto entity)
        {
            var s = entity.ToSubscriberFromSubscriberDto();
            _subscribers.Add(s);
        }

        public void Update(string guid, SubscriberAddOrUpdateDto entity)
        {
            var dbSub = _subscribers.GetByGuid(guid);
            if (dbSub != null)
            {
                dbSub.Address = entity.Address;
                dbSub.Fullname = entity.Fullname;
                dbSub.PhoneNumber = entity.PhoneNumber;
                _subscribers.Update(dbSub);
            }
        }
        
        public void Remove(string guid)
        {
            var dbSub = _subscribers.GetByGuid(guid);
            if (dbSub != null)
            {
                _subscribers.Remove(dbSub);
            }
        }
    }
}