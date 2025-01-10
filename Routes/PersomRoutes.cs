namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            app.MapGet("/person", () => new Model.Person("Murilo", "Mu_bissiato@Hotmail.com"));
        }
    }
}
