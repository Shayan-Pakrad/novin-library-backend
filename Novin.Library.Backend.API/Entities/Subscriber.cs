using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Entities
{
    public class Subscriber : Thing
    {
        public required string Fullname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}