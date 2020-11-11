using Microsoft.Extensions.DependencyInjection;
using TMSA.PIZZARIA.Cadastro.Data.Repository;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Services;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Services;

namespace TMSA.PIZZARIA.Core.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            // Services
            service.AddScoped<IClienteServices, ClienteServices>();
            service.AddScoped<IProdutoServices, ProdutoServices>();

            // Domain-Repository
            service.AddScoped<IClienteRepository, ClienteRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}