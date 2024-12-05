using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Author = bookModel.Author,
                Guid = bookModel.Guid,
                Title = bookModel.Title,
                Price = bookModel.Price,
                PriceBeTooman = bookModel.Price / 10
            };
        }
        public static Book ToBookFromBookDto(this BookAddOrUpdateDto bookDto) {
            return new Book
            {
                Author = bookDto.Author,
                Price = bookDto.Price,
                Title = bookDto.Title
            };
        }
        
    }
}