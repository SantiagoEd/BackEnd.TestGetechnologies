using BackEnd.TestGetechnologies.Repository;
using BackEnd.TestGetechnologies.Service.Persona;
using BackEnd.TestGetechnologies.Models;
using BackEnd.TestGetechnologies.Service.Factura;

namespace BackEnd.TestGetechnologies.Service.Configuracion
{
    internal static class ManagerConfigurationServices
    {
        internal static IServiceCollection AddAplicationServices(this IServiceCollection services)
            => services.AddScoped<IPersonServices, PersonServices>()
                .AddScoped<IInvoiceServices, InvoiceServices>()
                .AddScoped<IRepository<Guid, Models.Persona>, Repository<Guid, Models.Persona>>()
                .AddScoped<IRepository<int, Models.Factura>, Repository<int, Models.Factura>>();
    }
}
