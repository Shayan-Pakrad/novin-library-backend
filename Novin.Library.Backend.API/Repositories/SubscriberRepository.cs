using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.Repositories
{
    public class SubscriberRepository : GenericRepository<Subscriber>
    {
        public SubscriberRepository(LibraryDB db) : base(db)
        {
        }

        public override IQueryable<Subscriber> GetAll()
        {
            return base.GetAll().Where(m=>m.PhoneNumber!=null);
        }
    }
}