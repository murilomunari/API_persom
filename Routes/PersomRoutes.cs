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
                return Results.Created($"/person/{person.Id}", person);
            });

            route.MapGet("", async (PersonContext context) =>
            {
                var people = await context.People.ToListAsync();
                return Results.Ok(people);
            });

            route.MapGet("/{name}", async (string name, PersonContext context) =>
            {
                var person = await context.People.FirstOrDefaultAsync(p => p.Name == name);

                if (person == null) return Results.NotFound("Person not found");
                return Results.Ok(person);
            });

            route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
            {
                var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                if (person == null)
                    return Results.NotFound("Person not found");

                person.ChangeName(req.name);
                await context.SaveChangesAsync();

                return Results.Ok(person);
            });

            route.MapDelete("/{name}", async (string name, PersonContext context) =>
            {
                var person = await context.People.FirstOrDefaultAsync(x => x.Name == name);

                if (person == null)
                    return Results.NotFound("Person not found");

                context.People.Remove(person);
                await context.SaveChangesAsync();

                return Results.Ok($"Person '{name}' deleted successfully.");
            });
        }
    }
}
