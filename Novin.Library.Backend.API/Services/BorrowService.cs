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
            .Select(b => new BorrowDto{
                Guid = b.Guid,
                BorrowDate = b.BorrowDate,
                Book = new BookDto{
                    Guid = b.Book.Guid,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Price = b.Book.Price,
                    PriceBeTooman = b.Book.Price / 10
                },
                Subscriber = new SubscriberDto{
                    Guid = b.Subscriber.Guid,
                    Fullname = b.Subscriber.Fullname,
                    PhoneNumber = b.Subscriber.PhoneNumber,
                    Address = b.Subscriber.Address
                },
            })
            .ToList();
        }

        public void Add(BorrowAddOrUpdateDto entity)
        {
            var b = new Borrow{
                BorrowDate = entity.BorrowDate,
                ReturnDate = entity.ReturnDate,
                BookId = _books.GetByGuid(entity.BookGuid)?.Id??0,
                SubscriberId = _subscribers.GetByGuid(entity.SubscriberGuid)?.Id??0
            };
            _borrows.Add(b);
        }

        public void Update(string guid, BorrowAddOrUpdateDto entity)
        {
            var dbBorrow = _borrows.GetByGuid(guid);
            if (dbBorrow != null)
            {
                dbBorrow.BookId = _books.GetByGuid(entity.BookGuid)?.Id??0;
                dbBorrow.BorrowDate = entity.BorrowDate;
                dbBorrow.ReturnDate = entity.ReturnDate;
                dbBorrow.SubscriberId = _subscribers.GetByGuid(entity.SubscriberGuid)?.Id??0;
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