using Microsoft.EntityFrameworkCore;
using DexLK.Address.Models;

namespace DexLK.Address.Model.DBContexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Address.Models.Wallet> Wallet { get; set; }
        public DbSet<Models.Exchange> Exchange { get; set; }       

    }
}
