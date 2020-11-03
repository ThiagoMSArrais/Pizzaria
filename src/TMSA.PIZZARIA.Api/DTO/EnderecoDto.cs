using System;

namespace TMSA.PIZZARIA.Api.DTO
{
    public class EnderecoDto
    {
        public EnderecoDto()
        {
            IdEndereco = Guid.NewGuid();
        }

        public Guid IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}