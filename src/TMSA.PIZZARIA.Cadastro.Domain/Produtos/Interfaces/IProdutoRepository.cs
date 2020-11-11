﻿using System;
using System.Collections.Generic;

namespace TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces
{
    public interface IProdutoRepository
    {
        void CadastrarProduto(Produto produto);
        void AtualizarProduto(Produto prodto);
        Produto ObterProdutoPorId(Guid idProduto);
        Produto ObterprodutoPorCategoria(Guid idCategoria);
        IEnumerable<Produto> ObterProdutos();
        void RemoverProduto(Guid idProduto);
        void CadastrarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
        Categoria ObterCategoriaPorId(Guid idCategoria);
        IEnumerable<Categoria> ObterCategorias();
        void RemoverCategoria(Guid idCategoria);

    }
}
