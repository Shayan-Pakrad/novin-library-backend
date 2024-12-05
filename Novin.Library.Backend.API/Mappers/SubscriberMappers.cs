using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Mappers
{
    public static class SubscriberMappers
    {
        public static SubscriberDto ToSubscriberDto(this Subscriber subscriberModel)
        {
            return new SubscriberDto
            {
                Address = subscriberModel.Address,
                Fullname = subscriberModel.Fullname,
                Guid = subscriberModel.Guid,
                PhoneNumber = subscriberModel.PhoneNumber
            };
        }

        public static Subscriber ToSubscriberFromSubscriberDto(this SubscriberAddOrUpdateDto subscriberDto)
        {
            return new Subscriber
            {
                Fullname = subscriberDto.Fullname,
                Address = subscriberDto.Address,
                PhoneNumber = subscriberDto.PhoneNumber
            };
        }

    }
}