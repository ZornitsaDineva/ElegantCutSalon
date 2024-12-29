using ElegantCutSalon.Controllers;
using ElegantCutSalon.Database;

namespace ElegantCutSalon
{
    public class Program
    {
        private static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ElegantCutSalonMin;Trusted_Connection=True;";


        public static void Main(string[] args)
        {
            // dotnet add package <PACKAGE_NAME> 



            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<DatabaseManager>
                (s => new DatabaseManager(connectionString));


            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            
            new AdminController(app);

           


            app.Run();
        }
    }
}
