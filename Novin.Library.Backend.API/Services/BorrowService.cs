using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Borrows;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Services
{
    public class BorrowService : IService<Borrow, BorrowDto, BorrowAddOrUpdateDto>
    {
        private readonly IRepository<Borrow> _borrows;

        public BorrowService(IRepository<Borrow> borrows)
        {
            _borrows = borrows;
        }

        public IEnumerable<BorrowDto> List()
        {
            return _borrows.GetAll()
            .Select(b => new BorrowDto{
                Guid = b.Guid,
                BorrowDate = b.BorrowDate,
                ReturnDate = b.ReturnDate,
                Book = b.Book,
                BookId = b.BookId,
                Subscriber = b.Subscriber,
                SubscriberId = b.SubscriberId
            })
            .ToList();
        }

        public void Add(BorrowAddOrUpdateDto entity)
        {
            var b = new Borrow{
                BorrowDate = entity.BorrowDate,
                ReturnDate = entity.ReturnDate,
                BookId = entity.BookId,
                SubscriberId = entity.SubscriberId
            };
            _borrows.Add(b);
        }

        public void Update(string guid, BorrowAddOrUpdateDto entity)
        {
            var dbBorrow = _borrows.GetByGuid(guid);
            if (dbBorrow != null)
            {
                dbBorrow.BookId = entity.BookId;
                dbBorrow.BorrowDate = entity.BorrowDate;
                dbBorrow.ReturnDate = entity.ReturnDate;
                dbBorrow.SubscriberId = entity.SubscriberId;
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