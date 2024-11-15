using Microsoft.EntityFrameworkCore;
using OVS.Database;

namespace OVS.Database
{
    public class SQLiteDBContext : DbContext
    {
        public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
