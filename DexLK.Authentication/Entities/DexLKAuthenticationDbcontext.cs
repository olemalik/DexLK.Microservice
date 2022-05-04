using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexLK.Authentication.Entities
{
    public class DexLKAuthenticationDbContext : DbContext
    {
        public DexLKAuthenticationDbContext(DbContextOptions<DexLKAuthenticationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
