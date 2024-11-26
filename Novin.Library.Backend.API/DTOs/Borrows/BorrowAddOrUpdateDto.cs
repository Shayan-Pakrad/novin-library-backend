using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.DTOs.Borrows
{
    public class BorrowAddOrUpdateDto
    {
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public required string BookGuid { get; set; }
        public required string SubscriberGuid { get; set; }
    }
}