using ElegantCutSalon.Database;
using ElegantCutSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElegantCutSalon.Controllers
{
    public class AdminController
    {

        public AdminController(WebApplication app)
        {

            app.MapGet("/login", (HttpContext httpContext) => {
                return Results.Content(File.ReadAllText("Views/login.html"),
                    "text/html");
            });
            app.MapPost("/login", (HttpContext httpContext, [FromForm] Login s) =>
            {
                Console.WriteLine(s.Password);
                Console.WriteLine(s.Email);

                return Results.Redirect("/register");
            }).DisableAntiforgery();

            app.MapGet("/register", (HttpContext httpContext) => {
                return Results.Content(File.ReadAllText("Views/register.html"),
                    "text/html");
            });
            app.MapPost("/staff", static (HttpContext httpContext, 
                [FromForm] StaffModel s, DatabaseManager database) =>
            {
                database.InsertStaff(s.Name, s.Title, s.Description, s.Role, s.Email, s.Password, s.IsAdmin);



            }).DisableAntiforgery();
        }

        
    }
}
