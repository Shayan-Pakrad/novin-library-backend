using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Repositories
{
    public class BorrowRepository : GenericRepository<Borrow>
    {
        // Class ctor
        public BorrowRepository(LibraryDB db) : base(db)
        {
        }
        // Some class methods implementations
        public override IQueryable<Borrow> GetAll()
        {
            return base.GetAll().Where(m => m.ReturnDate == null);
        }
        public override Borrow? GetById(int id)
        {
            var result = base.GetById(id);
            if (result != null && result.ReturnDate != null)
            {
                return null;
            }
            return result;
        }
        public override Borrow? GetByGuid(string guid)
        {
            var result = base.GetByGuid(guid);
            if (result != null && result.ReturnDate != null)
            {
                return null;
            }
            return result;
        }

    }
}