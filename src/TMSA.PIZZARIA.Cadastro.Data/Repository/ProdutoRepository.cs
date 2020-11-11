using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public void AtualizarProduto(Produto produto)
        {
            using (IDbConnection con = Connection)
            {
                string sqlAtualizarProduto = $"UPDATE T_PRODUTO " +
                                              "SET NM_PRODUTO = @NM_PRODUTO," +
                                              "VL_PROUTO = @VL_PRODUTO, " +
                                              $"{(!string.IsNullOrEmpty(produto.Descricao) ? "DS_PRODUTO = @DS_PRODUTO, " : string.Empty)}" +
                                                   "NU_QTD_PRODUTO = @NU_QTD_PRODUTO, " +
                                                   "CD_CATEGORIA = @CD_CATEGORIA " +
                                               "WHERE " +
                                                   "ID_PRODUTO = @ID_PRODUTO";

                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("ID_PRODUTO", produto.IdProduto, DbType.Guid, ParameterDirection.Input);
                parametros.Add("NM_PRODUTO", produto.Nome, DbType.String, ParameterDirection.Input);
                parametros.Add("VL_PRODUTO", produto.Preco, DbType.Decimal, ParameterDirection.Input);
                parametros.Add("NU_QTD_PRODUTO", produto.Quantidade, DbType.Int32, ParameterDirection.Input);
                parametros.Add("CD_CATEGORIA", produto.Categoria.IdCategoria, DbType.Guid, ParameterDirection.Input);
                if (!string.IsNullOrEmpty(produto.Descricao))
                    parametros.Add("DS_PRODUTO", produto.Descricao, DbType.String, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    con.Execute(sql: sqlAtualizarProduto, param: parametros);
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

        public void CadastrarCategoria(Categoria categoria)
        {
            using (IDbConnection con = Connection)
            {
                string sqlCadastrarCategoria = $"INSERT INTO T_CATEGORIA" +
                                                   $"(" +
                                                       $"ID_CATEGORIA," +
                                                       $"DS_CATEGORIA " +
                                                   $")" +
                                                   $"VALUES " +
                                                   $"( " +
                                                       $"@ID_CATEGORIA," +
                                                       $"@DS_CATEGORIA " +
                                                   $")";

                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("ID_CATEGORIA", categoria.IdCategoria, DbType.Guid, ParameterDirection.Input);
                parametros.Add("DS_CATEGORIA", categoria.Tipo, DbType.String, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    con.Execute(sql: sqlCadastrarCategoria, param: parametros);
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

        public void CadastrarProduto(Produto produto)
        {
            using (IDbConnection con = Connection)
            {
                string sqlCadastrarProduto = $"INSERT INTO T_PRODUTO " +
                                             $"(" +
                                                 $"ID_PRODUTO," +
                                                 $"NM_PRODUTO," +
                                                 $"VL_PRODUTO, " +
                                                 $"{(!string.IsNullOrEmpty(produto.Descricao) ? "DS_PRODUTO, " : string.Empty)}" +
                                                 $"NU_QTD_PRODUTO," +
                                                 $"CD_CATEGORIA" +
                                             $") " +
                                             $"VALUES " +
                                             $"(" +
                                                 $"@ID_PRODUTO," +
                                                 $"@NM_PRODUTO," +
                                                 $"@VL_PRODUTO," +
                                                 $"{(!string.IsNullOrEmpty(produto.Descricao) ? "@DS_PRODUTO, " : string.Empty)}" +
                                                 $"@NU_QTD_PRODUTO," +
                                                 $"@CD_CATEGORIA" +
                                             $") ";

                
                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("ID_PRODUTO", produto.IdProduto, DbType.Guid, ParameterDirection.Input);
                parametros.Add("NM_PRODUTO", produto.Nome, DbType.String, ParameterDirection.Input);
                parametros.Add("VL_PRODUTO", produto.Preco, DbType.Decimal, ParameterDirection.Input);
                parametros.Add("NU_QTD_PRODUTO", produto.Quantidade, DbType.Int32, ParameterDirection.Input);
                parametros.Add("CD_CATEGORIA", produto.Categoria.IdCategoria, DbType.Guid, ParameterDirection.Input);
                
                if (!string.IsNullOrEmpty(produto.Descricao))
                    parametros.Add("DS_PRODUTO", produto.Descricao, DbType.String, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    con.Execute(sql: sqlCadastrarProduto, param: parametros);
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
        public Categoria ObterCategoriaPorId(Guid idCategoria)
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterCategoriaPorId = @"SELECT 
                                                          CATE.ID_CATEGORIA AS IdCategoria,
                                                          CATE.DS_CATEGORIA AS Tipo
                                               
                                                  FROM  
                                                         T_CATEGORIA CATE
                                                  WHERE
                                                         CATE.ID_CATEGORIA = @IDCATEGORIA";

                Categoria categoria = default(Categoria);

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IDCATEGORIA", idCategoria, DbType.Guid, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    categoria = con.QueryFirstOrDefault<Categoria>(sql: sqlObterCategoriaPorId, param: parametros);
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

                return categoria;
            }
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterCategorias = @"SELECT 
                                                      CATE.ID_CATEGORIA AS IdCategoria,
                                                      CATE.DS_CATEGORIA AS Tipo

                                              FROM  
                                                     T_CATEGORIA CATE";

                IEnumerable<Categoria> categorias = default(IEnumerable<Categoria>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    categorias = con.Query<Categoria>(sql: sqlObterCategorias);
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

                return categorias;
            }
        }

        public Produto ObterprodutoPorCategoria(Guid idCategoria)
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterProdutosPorId = @"SELECT 
                                                         PROD.ID_PRODUTO AS IdProduto,
                                                         PROD.NM_PRODUTO AS Nome,
                                                         PROD.DS_PRODUTO AS Descricao,
                                                         PROD.VL_PRODUTO AS Preco,
                                                         PROD.NU_QTD_PRODUTO AS Quantidade,
                                                         CATE.ID_CATEGORIA AS IdCategoria,
                                                         CATE.DS_CATEGORIA AS Tipo
                                                
                                                  FROM  
                                                          T_PRODUTO PROD
                                                          JOIN T_CATEGORIA CATE 
                                                          ON PROD.CD_CATEGORIA = CATE.ID_CATEGORIA
                                                  WHERE
                                                          PROD.CD_CATEGORIA = @IDCATEGORIA";

                IEnumerable<Produto> produto = default(IEnumerable<Produto>);

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IDCATEGORIA", idCategoria, DbType.Guid, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    produto = con.Query<Produto, Categoria, Produto>(sql: sqlObterProdutosPorId, param: parametros,
                                      map: (produto, categoria) =>
                                      {
                                          produto.Categoria = categoria;
                                          return produto;
                                      }, splitOn: "IdCategoria");
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

                return produto.FirstOrDefault();
            }
        }

        public Produto ObterProdutoPorId(Guid idProduto)
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterProdutosPorId = @"SELECT 
                                                         PROD.ID_PRODUTO AS IdProduto,
                                                         PROD.NM_PRODUTO AS Nome,
                                                         PROD.DS_PRODUTO AS Descricao,
                                                         PROD.VL_PRODUTO AS Preco,
                                                         PROD.NU_QTD_PRODUTO AS Quantidade,
                                                         CATE.ID_CATEGORIA AS IdCategoria,
                                                         CATE.DS_CATEGORIA AS Tipo
                                                
                                                  FROM  
                                                          T_PRODUTO PROD
                                                          JOIN T_CATEGORIA CATE 
                                                          ON PROD.CD_CATEGORIA = CATE.ID_CATEGORIA
                                                  WHERE
                                                          PROD.ID_PRODUTO = @IDPRODUTO";

                IEnumerable<Produto> produto = default(IEnumerable<Produto>);

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IDPRODUTO", idProduto, DbType.Guid, ParameterDirection.Input);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    produto = con.Query<Produto, Categoria, Produto>(sql: sqlObterProdutosPorId, param: parametros,
                                      map: (produto, categoria) =>
                                      {
                                          produto.Categoria = categoria;
                                          return produto;
                                      }, splitOn: "IdCategoria");
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

                return produto.FirstOrDefault();
            }
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            using(IDbConnection con = Connection)
            {
                string sqlObterProdutos = @"SELECT 
                                                    PROD.ID_PRODUTO AS IdProduto,
                                                    PROD.NM_PRODUTO AS Nome,
                                                    PROD.DS_PRODUTO AS Descricao,
                                                    PROD.VL_PRODUTO AS Preco,
                                                    PROD.NU_QTD_PRODUTO AS Quantidade,
                                                    CATE.ID_CATEGORIA AS IdCategoria,
                                                    CATE.DS_CATEGORIA AS Tipo

                                             FROM  
                                                     T_PRODUTO PROD
                                                     JOIN T_CATEGORIA CATE 
                                                     ON PROD.CD_CATEGORIA = CATE.ID_CATEGORIA";

                IEnumerable<Produto> produtos = default(IEnumerable<Produto>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    produtos = con.Query<Produto, Categoria, Produto>(sql: sqlObterProdutos,
                                        map: (produto, categoria) =>
                                        {
                                            produto.Categoria = categoria;
                                            return produto;
                                        }, splitOn: "IdCategoria");
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

                return produtos;
            }
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
