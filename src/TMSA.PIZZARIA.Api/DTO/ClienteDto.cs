using System;

namespace TMSA.PIZZARIA.Api.DTO
{
    public class ClienteDto
    {
        public ClienteDto()
        {
            IdCliente = Guid.NewGuid();
        }

        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
