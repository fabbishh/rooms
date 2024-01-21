using HousingReservation.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ReservationDbContext>())
                {
                    try
                    {
                        if (appContext.Database.GetPendingMigrations().Any())
                        {
                            appContext.Database.Migrate();
                            DataSeeder.SeedData(appContext);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
