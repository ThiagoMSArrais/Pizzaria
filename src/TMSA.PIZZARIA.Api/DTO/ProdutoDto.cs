using System;

namespace TMSA.PIZZARIA.Api.DTO
{
    public class ProdutoDto
    {
        public ProdutoDto()
        {
            IdProduto = Guid.NewGuid();
        }

        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int? Quantidade { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
}