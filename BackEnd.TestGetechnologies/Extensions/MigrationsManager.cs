using BackEnd.TestGetechnologies.Data;

namespace BackEnd.TestGetechnologies
{
    public static class MigrationsManager
    {
        public static IHost MigrateDataBase(this IHost host) 
        {
            using (var scope = host.Services.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>()) 
            {
                try
                {
                    /* Utilizamos EnsureCreated ya que no se modificara la BD solo se valida que exista de lo contrario seria 
                     appContext.Database.Migrate();
                     */
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex) 
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "A ocurrido un error al configurar la BD.");
                }
            }
            return host;
        }
    }
}
