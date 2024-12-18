using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Mappers;

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
        public async Task<IEnumerable<BookDto>> ListAsync()
        {
            return await _books.GetAll()
            .Select(b=> b.ToBookDto())
            .ToListAsync();
        }

        public async Task<int> AddAsync(BookAddOrUpdateDto entity)
        {
            var b = entity.ToBookFromBookDto();
            return await _books.AddAsync(b);
        }

        public async Task<int> UpdateAsync(string guid, BookAddOrUpdateDto entity)
        {
            var dbBook = await _books.GetByGuidAsync(guid);
            if (dbBook != null)
            {
                dbBook.Author = entity.Author;
                dbBook.Price = entity.Price;
                dbBook.Title = entity.Title;
                return await _books.UpdateAsync(dbBook);
            }
            return 0;
        }

        public async Task<int> RemoveAsync(string guid)
        {
            var dbBook = await _books.GetByGuidAsync(guid);
            if (dbBook != null)
            {
                return await _books.RemoveAsync(dbBook);
            }
            return 0;
        }
        
    }
}