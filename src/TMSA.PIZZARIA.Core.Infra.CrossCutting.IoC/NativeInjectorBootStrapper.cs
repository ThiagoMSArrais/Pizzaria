using Microsoft.Extensions.DependencyInjection;
using TMSA.PIZZARIA.Cadastro.Data.Repository;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Services;

namespace TMSA.PIZZARIA.Core.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            // Services
            service.AddScoped<IClienteServices, ClienteServices>();

            // Domain-Repository
            service.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}