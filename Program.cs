using Microsoft.AspNetCore.Mvc;
using ElegantCutSalon.Models;
using Microsoft.AspNetCore.Antiforgery;
namespace ElegantCutSalon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapGet("/", (HttpContext httpContext) => {
                return Results.Content("""
                    <h1> Register Staff </h1>
                    <form action="/staff" method="post">
                        
                        <lable>Name</lable>
                        <input type="text" name="Name" placeholder="Name" required>

                    <lable>Title</lable>
                        <input type="text" name="Title" placeholder="Title" required>

                    <lable>Description</lable>
                        <input type="text" name="Description" placeholder="Description" required>

                    <lable>Email</lable>
                        <input type="email" name="Email" placeholder="Email" required>

                    <lable>Role</lable>
                        <input type="text" name="Role" placeholder="Role" required>

                    <lable>Password</lable>
                        <input type="password" name="Password" placeholder="Password" required>

                        <input type="submit" value="Submit" />

                    </form>
                    """, "text/html");
            });

            app.MapPost("/staff", (HttpContext httpContext, [FromForm] StaffModel s) =>
            {
                Console.WriteLine(s.Name);
                Console.WriteLine(s.Title);
                Console.WriteLine(s.Description);
                Console.WriteLine(s.Role);
                Console.WriteLine(s.Email);
                Console.WriteLine(s.Password);
            }).DisableAntiforgery();

            app.Run();
        }
    }
}
