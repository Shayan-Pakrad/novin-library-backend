using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Services
{
    public class BookService : IService<Book, BookDto, BookAddOrUpdateDto>
    {

        // An instance of the Book Repository
        private readonly IRepository<Book> _books;
        // ctor
        public BookService(IRepository<Book> books)
        {
            _books = books;
        }

        // Method implementations
        public IEnumerable<BookDto> List()
        {
            return _books.GetAll()
            .Select(b=>new BookDto
            {
                Guid = b.Guid,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price
            })
            .ToList();
        }

        public void Add(BookAddOrUpdateDto entity)
        {
            var b = new Book{
                Title = entity.Title,
                Author = entity.Author,
                Price = entity.Price
            };
            _books.Add(b);
        }

        public void Update(string guid, BookAddOrUpdateDto entity)
        {
            var dbBook = _books.GetByGuid(guid);
            if (dbBook != null)
            {
                dbBook.Author = entity.Author;
                dbBook.Price = entity.Price;
                dbBook.Title = entity.Title;
                _books.Update(dbBook);
            }
        }

        public void Remove(string guid)
        {
            var dbBook = _books.GetByGuid(guid);
            if (dbBook != null)
            {
                _books.Remove(dbBook);
            }
        }
        
    }
}