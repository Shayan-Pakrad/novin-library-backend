using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.DTOs.Borrows
{
    public class BorrowDto
    {
        public required string Guid { get; set; }
        public DateTime BorrowDate { get; set; }
        public int BookId { get; set; }
        public BookDto? Book { get; set; }
        public int SubscriberId { get; set; }
        public SubscriberDto? Subscriber { get; set; }
    }
}