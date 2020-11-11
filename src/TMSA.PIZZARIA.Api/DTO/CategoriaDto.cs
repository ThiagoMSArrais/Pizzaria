using System;

namespace TMSA.PIZZARIA.Api.DTO
{
    public class CategoriaDto
    {
        public CategoriaDto()
        {
            IdCategoria = Guid.NewGuid();
        }

        public Guid IdCategoria { get; set; }
        public string Tipo { get; set; }
    }
}