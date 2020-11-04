using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces;

namespace TMSA.PIZZARIA.Cadastro.Domain.Produtos.Services
{
    public class ProdutoServices : IProdutoServices
    {
        public void AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void AtualizarProduto(Produto prodto)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void CadastrarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Categoria ObterCategoriaPorId(Guid idCategoria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Produto ObterprodutoPorCategoria(Guid idCategoria)
        {
            throw new NotImplementedException();
        }

        public Produto ObterProdutoPorId(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            throw new NotImplementedException();
        }

        public void RemoverCategoria(Guid idCategoria)
        {
            throw new NotImplementedException();
        }

        public void RemoverProduto(Guid idProduto)
        {
            throw new NotImplementedException();
        }
    }
}
