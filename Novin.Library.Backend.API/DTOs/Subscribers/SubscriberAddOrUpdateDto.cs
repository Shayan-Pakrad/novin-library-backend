using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Library.Backend.API.DTOs.Subscribers
{
    public class SubscriberAddOrUpdateDto
    {
        public required string Fullname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}