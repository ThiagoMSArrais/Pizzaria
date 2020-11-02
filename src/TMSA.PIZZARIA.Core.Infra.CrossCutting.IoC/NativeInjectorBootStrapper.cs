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
            service.AddScoped<IClienteServices, ClienteServices>();

            service.AddScoped(IClienteRepository, ClienteRepository)
        }
    }
}
