using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Entities
{
    public class Book : Thing
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public double Price { get; set; }
    }
}