using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Library.Backend.API.DTOs.Subscribers
{
    public class SubscriberDto
    {
        public required string Guid { get; set; }
        public required string Fullname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}