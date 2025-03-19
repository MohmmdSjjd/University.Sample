using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Presentation.WebApi.Extensions
{
    public static class MigrationExtension
    {
        public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app)
            where TContext : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TContext>();

                context.Database.Migrate();
            }

            return app;
        }
    }
}

