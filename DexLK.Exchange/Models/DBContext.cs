using Microsoft.EntityFrameworkCore;
using DexLK.Exchange.Models;

namespace DexLK.Exchange.Model.DBContexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Models.Exchange> Exchange  { get; set; }       

    }
}
