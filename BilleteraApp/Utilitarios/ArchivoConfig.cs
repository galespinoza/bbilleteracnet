

namespace billetera.Utilitarios;
public class ArchivoConfig
{
    private static IConfiguration Configuration { get; set; }

    static ArchivoConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        Configuration = builder.Build();
    }

    public string LeerConfiguracion(string clave)
    {
        return Configuration[clave];
    }
}