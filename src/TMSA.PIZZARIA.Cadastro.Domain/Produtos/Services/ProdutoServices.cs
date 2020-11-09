using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces;

namespace TMSA.PIZZARIA.Cadastro.Domain.Produtos.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            _produtoRepository.AtualizarCategoria(categoria);
        }

        public void AtualizarProduto(Produto produto)
        {
            _produtoRepository.AtualizarProduto(produto);
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            _produtoRepository.CadastrarCategoria(categoria);
        }

        public void CadastrarProduto(Produto produto)
        {
            _produtoRepository.CadastrarProduto(produto);
        }

        public Categoria ObterCategoriaPorId(Guid idCategoria)
        {
            return _produtoRepository.ObterCategoriaPorId(idCategoria);
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _produtoRepository.ObterCategorias();
        }

        public Produto ObterprodutoPorCategoria(Guid idCategoria)
        {
            return _produtoRepository.ObterprodutoPorCategoria(idCategoria);
        }

        public Produto ObterProdutoPorId(Guid idProduto)
        {
            return _produtoRepository.ObterProdutoPorId(idProduto);
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            return _produtoRepository.ObterProdutos();
        }

        public void RemoverCategoria(Guid idCategoria)
        {
            _produtoRepository.RemoverCategoria(idCategoria);
        }

        public void RemoverProduto(Guid idProduto)
        {
            _produtoRepository.RemoverProduto(idProduto);
        }
    }
}
