using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(LibraryDB db) : base(db)
        {
        }
        public override IQueryable<Book> GetAll()
        {
            return base.GetAll().Where(b => b.Price > 0);
        }
        public override void Add(Book entity)
        {
            if (entity.Author != "ali")
            {
                base.Add(entity);
            }
        }
    }
}