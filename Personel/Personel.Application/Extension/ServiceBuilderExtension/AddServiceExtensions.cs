using System.Reflection;
namespace Personel.Personel.Application.Extension.ServiceBuilderExtension;

public static class AddServiceExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract).ToList();

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();

            foreach (var item in interfaces)
            {
                services.AddScoped(item, type);
            }
        }

        return services;
    }
}