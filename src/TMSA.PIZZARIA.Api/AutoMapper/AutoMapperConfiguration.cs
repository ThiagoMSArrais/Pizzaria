using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TMSA.PIZZARIA.Api.DTO;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos;

namespace TMSA.PIZZARIA.Api.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<EnderecoDto, Endereco>().ReverseMap();
            CreateMap<ProdutoDto, Produto>().ReverseMap();
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
        }
    }

    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
