using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities.Base;

namespace Novin.Library.Backend.API.Entities
{
    public class Borrow : Thing
    {
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
        public Subscriber? Subscriber { get; set; }
        public int SubscriberId { get; set; }
    }
}