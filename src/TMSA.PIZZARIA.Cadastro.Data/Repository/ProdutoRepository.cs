using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces;
using TMSA.PIZZARIA.Core.Data.Connection;

namespace TMSA.PIZZARIA.Cadastro.Data.Repository
{
    public class ProdutoRepository : ConnectionDB, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            using(IDbConnection con = Connection)
            {
                string sqlAtualizarCategoria = @"UPDATE T_CATEGORIA 
                                                 SET DS_CATEGORIA = @CATEGORIA
                                                 WHERE
                                                        ID_CATEGORIA = @IDCATEGORIA";

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("CATEGORIA", categoria.Tipo, DbType.String, ParameterDirection.Input);
                parametros.Add("IDCATEGORIA", categoria.IdCategoria, DbType.Guid, ParameterDirection.Input);

                try
                {
                    con.Execute(sql: sqlAtualizarCategoria, param: parametros);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
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
            using (IDbConnection con = Connection)
            {
                string sqlRemoverCategoria = @"DELETE T_CATEGORIA WHERE ID_CATEGORIA = @IDCATEGORIA";

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IDCATEGORIA", idCategoria, DbType.Guid, ParameterDirection.Input);

                try
                {
                    con.Execute(sql: sqlRemoverCategoria, param: parametros);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public void RemoverProduto(Guid idProduto)
        {
            using (IDbConnection con = Connection)
            {
                string sqlRemoverProduto = @"DELETE T_PRODUTO WHERE ID_PRODUTO = @IDPRODUTO";

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IDPRODUTO", idProduto, DbType.Guid, ParameterDirection.Input);

                try
                {
                    con.Execute(sql: sqlRemoverProduto, param: parametros);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
