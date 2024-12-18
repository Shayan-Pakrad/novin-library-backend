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

        public async Task<IEnumerable<BorrowDto>> ListAsync()
        {
            return await _borrows.GetAll()
            .Include(m => m.Book)
            .Include(m => m.Subscriber)
            .Select(b => b.ToBorrowDto())
            .ToListAsync();
        }

        public async Task<int> AddAsync(BorrowAddOrUpdateDto entity)
        {
            var bookId = (await _books.GetByGuidAsync(entity.BookGuid))?.Id ?? 0;
            var subId = (await _subscribers.GetByGuidAsync(entity.SubscriberGuid))?.Id ?? 0;
            var b = entity.ToBorrowFromBorrowDto(bookId, subId);
            return await _borrows.AddAsync(b);
        }

        public async Task<int> UpdateAsync(string guid, BorrowAddOrUpdateDto entity)
        {
            var dbBorrow = await _borrows.GetByGuidAsync(guid);
            if (dbBorrow != null)
            {
                dbBorrow.BookId = (await _books.GetByGuidAsync(entity.BookGuid))?.Id ?? 0;
                dbBorrow.BorrowDate = entity.BorrowDate;
                dbBorrow.ReturnDate = entity.ReturnDate;
                dbBorrow.SubscriberId = (await _subscribers.GetByGuidAsync(entity.SubscriberGuid))?.Id ?? 0;
                return await _borrows.UpdateAsync(dbBorrow);
            }
            return 0;
        }

        public async Task<int> RemoveAsync(string guid)
        {
            var dbBorrow = await _borrows.GetByGuidAsync(guid);
            if (dbBorrow != null)
            {
                return await _borrows.RemoveAsync(dbBorrow);
            }
            return 0;
        }
    }
}