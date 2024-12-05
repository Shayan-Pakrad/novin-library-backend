using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.DTOs.Borrows;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Mappers;

namespace Novin.Library.Backend.API.Services
{
    public class BorrowService : IService<Borrow, BorrowDto, BorrowAddOrUpdateDto>
    {
        private readonly IRepository<Borrow> _borrows;
        private readonly IRepository<Book> _books;
        private readonly IRepository<Subscriber> _subscribers;

        public BorrowService(IRepository<Borrow> borrows, IRepository<Book> books, IRepository<Subscriber> subscribers)
        {
            _borrows = borrows;
            _books = books;
            _subscribers = subscribers;
        }

        public IEnumerable<BorrowDto> List()
        {
            return _borrows.GetAll()
            .Include(m => m.Book)
            .Include(m => m.Subscriber)
            .Select(b => b.ToBorrowDto())
            .ToList();
        }

        public void Add(BorrowAddOrUpdateDto entity)
        {
            var b = entity.ToBorrowFromBorrowDto(_books.GetByGuid(entity.BookGuid)?.Id ?? 0, _subscribers.GetByGuid(entity.SubscriberGuid)?.Id ?? 0);
            _borrows.Add(b);
        }

        public void Update(string guid, BorrowAddOrUpdateDto entity)
        {
            var dbBorrow = _borrows.GetByGuid(guid);
            if (dbBorrow != null)
            {
                dbBorrow.BookId = _books.GetByGuid(entity.BookGuid)?.Id ?? 0;
                dbBorrow.BorrowDate = entity.BorrowDate;
                dbBorrow.ReturnDate = entity.ReturnDate;
                dbBorrow.SubscriberId = _subscribers.GetByGuid(entity.SubscriberGuid)?.Id ?? 0;
                _borrows.Update(dbBorrow);
            }
        }

        public void Remove(string guid)
        {
            var dbBorrow = _borrows.GetByGuid(guid);
            if (dbBorrow != null)
            {
                _borrows.Remove(dbBorrow);
            }
        }
    }
}