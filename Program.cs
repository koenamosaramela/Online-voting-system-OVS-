using Microsoft.EntityFrameworkCore;
using OVS.Database; // Adjust according to your actual namespace
using OVS.Initializers; // Adjust according to your actual namespace

namespace OVS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure SQLite DBContext
            builder.Services.AddDbContext<SQLiteDBContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register the database initializer
            builder.Services.AddScoped<IDBInitializer, DBInitializerRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Use a custom error page in production
                app.UseHsts(); // Add HSTS header in production
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Initialize the database
            InitializeDatabase(app);

            // Define the default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Run the application
            app.Run();
        }

        private static void InitializeDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitializer>();
                var dbContext = scope.ServiceProvider.GetRequiredService<SQLiteDBContext>();
                dbInitializer.Initialize(dbContext); // Call the initialization method
            }
        }
    }
}
