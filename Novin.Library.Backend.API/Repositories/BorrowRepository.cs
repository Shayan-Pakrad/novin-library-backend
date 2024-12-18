using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;

namespace Novin.Library.Backend.API.Repositories
{
    public class BorrowRepository : GenericRepository<Borrow>
    {
        // Class ctor
        public BorrowRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        // Some class methods implementations
        public override IQueryable<Borrow> GetAll()
        {
            return base.GetAll().Where(m => m.ReturnDate == null);
        }
        public override async Task<Borrow?> GetByIdAsync(int id)
        {
            var result = await base.GetByIdAsync(id);
            if (result != null && result.ReturnDate != null)
            {
                return null;
            }
            return result;
        }
        public override async Task<Borrow?> GetByGuidAsync(string guid)
        {
            var result = await base.GetByGuidAsync(guid);
            if (result != null && result.ReturnDate != null)
            {
                return null;
            }
            return result;
        }

    }
}