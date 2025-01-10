using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Model;

namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup("person");

            route.MapPost("", async (PersonRequest req, PersonContext context) =>
            {
                var person = new Model.Person(req.name, req.email);
                await context.AddAsync(person);
                await context.SaveChangesAsync();
            });

            route.MapGet("", async (PersonContext context) =>
            {
                var people = await context.People.ToListAsync();
                return Results.Ok(people);
            });
            
            route.MapGet("/{name}/{email}", async (string name, string email, PersonContext context) =>
            {
                var person = await context.People
                    .FirstOrDefaultAsync(p => p.Name == name && p.Email == email);

                if (person == null) return Results.NotFound("Person not found");
                return Results.Ok(person);
            });

        }
        
    }
}
