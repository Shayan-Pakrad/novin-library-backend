using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.DTOs.Borrows
{
    public class BorrowDto
    {
        public required string Guid { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
        public Subscriber? Subscriber { get; set; }
        public int SubscriberId { get; set; }
    }
}