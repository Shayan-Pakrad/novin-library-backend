using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Novin.Library.Backend.API.Entities
{
    public class LibraryUser : IdentityUser
    {
        public string? Fullname { get; set; }
        public string? Address { get; set; }
    }
}