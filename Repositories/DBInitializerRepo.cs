using System.Linq;
using OVS.Database;
using Microsoft.EntityFrameworkCore;

namespace OVS.Initializers
{
    public class DBInitializerRepo : IDBInitializer
    {
        // Remove the private SQLiteDBContext _context field, as we are passing it in the method
        public void Initialize(SQLiteDBContext context) // Match the method signature
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if any users exist
            if (!context.Users.Any())
            {
                SeedUsers(context);
            }

            // Add other seeding logic for other entities if needed
        }

        private void SeedUsers(SQLiteDBContext context) // Accept context as a parameter
        {
            var users = new[]
            {
                new User { Username = "admin", Password = "admin", IsRegistered = true },
                new User { Username = "user1", Password = "password1", IsRegistered = true },
                new User { Username = "user2", Password = "password2", IsRegistered = true },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
