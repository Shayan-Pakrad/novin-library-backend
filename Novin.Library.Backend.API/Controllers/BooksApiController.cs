using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Novin.Library.Backend.API.Controllers.Base;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Services;

namespace Novin.Library.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksApiController : BaseApiController<BookService, Book, BookDto, BookAddOrUpdateDto>
    {
        public BooksApiController(BookService service) : base(service)
        {
        }
    }
}