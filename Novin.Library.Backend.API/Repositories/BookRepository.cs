using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public override IQueryable<Book> GetAll()
        {
            return base.GetAll().Where(b => b.Price > 0);
        }
        public override async Task<int> AddAsync(Book entity)
        {
            if (entity.Author != "ali")
            {
                return await base.AddAsync(entity);
            }
            return 0;
        }
    }
}