using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DbContexts;

namespace Novin.Library.Backend.API.Middlewares
{
    public static class SecuritySeed
    {
        public static async Task<int> FirstRun(IServiceProvider sp)
        {
            var db = sp.GetRequiredService<LibraryDB>();
            if (await db.Roles.FirstOrDefaultAsync(m => m.Name == "Admin") == null)
            {
                var role = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                await db.Roles.AddAsync(role);
                await db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}