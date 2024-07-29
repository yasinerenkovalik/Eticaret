using Microsoft.Extensions.Configuration;

namespace Eticaret.Persistance;

public static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"/Users/yasinerenkovalik/projeler/eticaret/back/Eticaret/Eticaret.Api"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}