using BackEnd.TestGetechnologies.Service.Configuracion;

namespace BackEnd.TestGetechnologies.Helpers.StartConfiguration
{
    internal static class InjectionHelper
    {
        internal static IServiceCollection AddInjectionServices(this IServiceCollection services)
            => services.AddAplicationServices();
    }
}
