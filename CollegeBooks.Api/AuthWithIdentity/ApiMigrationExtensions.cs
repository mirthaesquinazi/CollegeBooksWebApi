using Microsoft.EntityFrameworkCore;

namespace CollegeBooks.Api.AuthWithIdentity
{
    public static class ApiMigrationExtensions
    {

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            //We can improve this adding a try catch sentences and if there is some error register a log or something.

            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApiDbContext context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

            context.Database.Migrate();

        }
    }
}
