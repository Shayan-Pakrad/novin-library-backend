using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Library.Backend.API.DTOs.Books
{
    public class BookAddOrUpdateDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public double Price { get; set; }
    }
}