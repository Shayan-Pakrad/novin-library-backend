using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.Entities;

namespace Novin.Library.Backend.API.DbContexts
{
    public class LibraryDB : IdentityDbContext<LibraryUser>
    {
        public LibraryDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
         
    }
}