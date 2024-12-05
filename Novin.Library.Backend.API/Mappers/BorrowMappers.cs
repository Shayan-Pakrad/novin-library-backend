using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Borrows;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Mappers
{
    public static class BorrowMappers
    {
        public static BorrowDto ToBorrowDto(this Borrow borrowModel)
        {
            return new BorrowDto
            {
                Guid = borrowModel.Guid,
                Book = borrowModel.Book.ToBookDto(),
                Subscriber = borrowModel.Subscriber.ToSubscriberDto(),
                BorrowDate = borrowModel.BorrowDate,
            };
        }
        public static Borrow ToBorrowFromBorrowDto(this BorrowAddOrUpdateDto borrowDto, int bookId, int subId)
        {
            return new Borrow
            {
                BorrowDate = borrowDto.BorrowDate,
                ReturnDate = borrowDto.ReturnDate,
                SubscriberId = subId,
                BookId = bookId
            };
        }

    }
}