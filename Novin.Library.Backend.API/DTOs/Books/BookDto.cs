using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Library.Backend.API.DTOs.Books
{
    public class BookDto
    {
        public required string Guid { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public double Price { get; set; }
    }
}