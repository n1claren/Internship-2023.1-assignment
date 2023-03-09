using EmployeeTaskSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskSystem.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var provider = scope.ServiceProvider;

            var data = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();

            data.SaveChanges();

            return app;
        }

    }
}
