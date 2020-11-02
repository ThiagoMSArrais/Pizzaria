using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;
using TMSA.PIZZARIA.Core.Data.Connection;

namespace TMSA.PIZZARIA.Cadastro.Data.Repository
{
    public class ClienteRepository : ConnectionDB, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using(IDbConnection con = Connection)
            {
                string sqlAtualizarCliente = @"UPDATE T_CLIENTE SET NU_TELEFONE = @Telefone
                                               WHERE
                                                      ID_CLIENTE = @IdCliente";

                string sqlAtualizaEndereco = $"UPDATE T_ENDERECO SET NM_LOGRADOURO = @Logradouro," +
                                                                     $"DS_NUMERO_ENDERECO = @Numero," +
                                                                     $"{ (!string.IsNullOrEmpty(cliente.Endereco.Complemento) ? "DS_COMPLEMENTO = @Complemento, " : string.Empty)}" +
                                                                     $"DS_BAIRRO = @Bairro," +
                                                                     $"DS_CIDADE = @Cidade," +
                                                                     $"DS_ESTADO = @Estado," +
                                                                     $"DS_CEP = @Cep " +
                                             $"WHERE" +
                                                                    $"ID_ENDERECO = @IdEndereco";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosCliente = new DynamicParameters();
                    parametrosCliente.Add("IdCliente", cliente.IdCliente, DbType.Guid, ParameterDirection.Input);
                    parametrosCliente.Add("Telefone", cliente.Telefone, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlAtualizarCliente, param: parametrosCliente);

                    DynamicParameters parametrosEndereco = new DynamicParameters();
                    parametrosEndereco.Add("IdEndereco", cliente.Endereco.IdEndereco, DbType.Guid, ParameterDirection.Input);
                    parametrosEndereco.Add("Logradouro", cliente.Endereco.Logradouro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("Numero", cliente.Endereco.Numero, DbType.String, ParameterDirection.Input);
                    if (!string.IsNullOrEmpty(cliente.Endereco.Complemento))
                        parametrosEndereco.Add("Complemento", cliente.Endereco.Complemento, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("Bairro", cliente.Endereco.Bairro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("Cidade", cliente.Endereco.Cidade, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("Estado", cliente.Endereco.Estado, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("Cep", cliente.Endereco.Cep, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlAtualizaEndereco, param: parametrosEndereco);
                }
                catch
                {

                    throw;
                }
            }
        }

        public void CadastrarCliente(Cliente cliente)
        {
            using(IDbConnection con = Connection)
            {
                string sqlCadastrarCliente = @"INSERT INTO T_CLIENTE 
                                               (
                                                   ID_CLIENTE,
                                                   NM_CLIENTE,
                                                   NU_TELEFONE
                                               )
                                               VALUES
                                               (
                                                   @ID_CLIENTE,
                                                   @NM_CLIENTE,
                                                   @NU_TELEFONE
                                               )";

                string sqlCadastrarEndereco = $"INSERT INTO T_ENDERECO " +
                                               $"(" +
                                               $"    ID_ENDERECO," +
                                               $"    NM_LOGRADOURO," +
                                               $"    DS_NUMERO_ENDERECO," +
                                               $"    {(!string.IsNullOrEmpty(cliente.Endereco.Complemento) ? "DS_COMPLEMENTO, " : string.Empty)}" +
                                               $"    DS_BAIRRO," +
                                               $"    DS_CIDADE," +
                                               $"    DS_ESTADO," +
                                               $"    DS_CEP," +
                                               $"    CD_CLIENTE" +
                                               $")" +
                                               $" VALUES" +
                                               $" (" +
                                               $"     @ID_ENDERECO," +
                                               $"     @NM_LOGRADOURO," +
                                               $"     @DS_NUMERO_ENDERECO," +
                                               $"     {(!string.IsNullOrEmpty(cliente.Endereco.Complemento) ? "@DS_COMPLEMENTO, " : string.Empty)}" +
                                               $"     @DS_BAIRRO," +
                                               $"     @DS_CIDADE," +
                                               $"     @DS_ESTADO," +
                                               $"     @DS_CEP," +
                                               $"     @CD_CLIENTE" +
                                               $" )";

                try
                {
                    DynamicParameters parametrosCliente = new DynamicParameters();
                    parametrosCliente.Add("ID_CLIENTE", cliente.IdCliente, DbType.Guid, ParameterDirection.Input);
                    parametrosCliente.Add("NM_CLIENTE", cliente.Nome, DbType.String, ParameterDirection.Input);
                    parametrosCliente.Add("NU_TELEFONE", cliente.Telefone, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlCadastrarCliente, param: parametrosCliente);

                    DynamicParameters parametrosEndereco = new DynamicParameters();
                    parametrosEndereco.Add("ID_ENDERECO", cliente.Endereco.IdEndereco, DbType.Guid, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_LOGRADOURO", cliente.Endereco.Logradouro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("DS_NUMERO_ENDERECO", cliente.Endereco.Numero, DbType.String, ParameterDirection.Input);
                    if (!string.IsNullOrEmpty(cliente.Endereco.Complemento))
                        parametrosEndereco.Add("DS_COMPLEMENTO", cliente.Endereco.Complemento, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("DS_BAIRRO", cliente.Endereco.Bairro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("DS_CIDADE", cliente.Endereco.Cidade, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("DS_ESTADO", cliente.Endereco.Estado, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("DS_CEP", cliente.Endereco.Cep, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("CD_CLIENTE", cliente.IdCliente, DbType.Guid, ParameterDirection.Input);

                    con.Execute(sqlCadastrarEndereco, param: parametrosEndereco);
                }
                catch
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

        public Cliente ObterClientePorId(Guid idCliente)
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterCliente = @"SELECT CLIE.ID_CLIENTE AS IdCliente,
                                                   CLIE.NM_CLIENTE AS Nome,
                                                   CLIE.NU_TELEFONE AS Telefone,
                                                   ENDE.ID_ENDERECO AS IdEndereco,
                                                   ENDE.NM_LOGRADOURO AS Logradouro,
                                                   ENDE.DS_NUMERO_ENDERECO AS Numero,
                                                   ENDE.DS_COMPLEMENTO AS Complemento,
                                                   ENDE.DS_BAIRRO AS Bairro,
                                                   ENDE.DS_CIDADE AS Cidade,
                                                   ENDE.DS_ESTADO AS Estado,
                                                   ENDE.DS_CEP AS AS Cep
                                                   FROM
                                                           T_CLIENTE AS CLIE
                                                           JOIN T_ENDERECO AS ENDE
                                                           ON CLIE.ID_CLIENTE = ENDE.CD_CLIENTE
                                                   WHERE
                                                           CLIE.ID_CLIENTE = @IdCliente";

                IEnumerable<Cliente> cliente = default(IEnumerable<Cliente>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametro = new DynamicParameters();
                    parametro.Add("IdCliente", idCliente, DbType.Guid, ParameterDirection.Input);

                    cliente = con.Query<Cliente, Endereco, Cliente>(sqlObterCliente,
                                       param: parametro,
                                       map: (cliente, endereco) =>
                                       {
                                           cliente.Endereco = endereco;
                                           return cliente;
                                       }, splitOn: "IdEndereco");

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return cliente.First();
            }
        }

        public Cliente ObterClientePorTelefone(string telefone)
        {
            using (IDbConnection con = Connection)
            {
                string sqlObterCliente = @"SELECT CLIE.ID_CLIENTE AS IdCliente,
                                                   CLIE.NM_CLIENTE AS Nome,
                                                   CLIE.NU_TELEFONE AS Telefone,
                                                   ENDE.ID_ENDERECO AS IdEndereco,
                                                   ENDE.NM_LOGRADOURO AS Logradouro,
                                                   ENDE.DS_NUMERO_ENDERECO AS Numero,
                                                   ENDE.DS_COMPLEMENTO AS Complemento,
                                                   ENDE.DS_BAIRRO AS Bairro,
                                                   ENDE.DS_CIDADE AS Cidade,
                                                   ENDE.DS_ESTADO AS Estado,
                                                   ENDE.DS_CEP AS AS Cep
                                                   FROM
                                                           T_CLIENTE AS CLIE
                                                           JOIN T_ENDERECO AS ENDE
                                                           ON CLIE.ID_CLIENTE = ENDE.CD_CLIENTE
                                                   WHERE
                                                           CLIE.NU_TELEFONE = @Telefone";

                IEnumerable<Cliente> cliente = default(IEnumerable<Cliente>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametro = new DynamicParameters();
                    parametro.Add("Telefone", telefone, DbType.String, ParameterDirection.Input);

                    cliente = con.Query<Cliente, Endereco, Cliente>(sqlObterCliente,
                                       param: parametro,
                                       map: (cliente, endereco) =>
                                       {
                                           cliente.Endereco = endereco;
                                           return cliente;
                                       }, splitOn: "IdEndereco");

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return cliente.First();
            }
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            using(IDbConnection con = Connection)
            {
                string sqlObterClientes = @"SELECT CLIE.ID_CLIENTE AS IdCliente,
                                                   CLIE.NM_CLIENTE AS Nome,
                                                   CLIE.NU_TELEFONE AS Telefone,
                                                   ENDE.ID_ENDERECO AS IdEndereco,
                                                   ENDE.NM_LOGRADOURO AS Logradouro,
                                                   ENDE.DS_NUMERO_ENDERECO AS Numero,
                                                   ENDE.DS_COMPLEMENTO AS Complemento,
                                                   ENDE.DS_BAIRRO AS Bairro,
                                                   ENDE.DS_CIDADE AS Cidade,
                                                   ENDE.DS_ESTADO AS Estado,
                                                   ENDE.DS_CEP AS AS Cep
                                                   FROM
                                                           T_CLIENTE AS CLIE
                                                           JOIN T_ENDERECO AS ENDE
                                                           ON CLIE.ID_CLIENTE = ENDE.CD_CLIENTE";

                IEnumerable<Cliente> clientes = default(IEnumerable<Cliente>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    clientes = con.Query<Cliente, Endereco, Cliente>(sqlObterClientes,
                                       map: (cliente, endereco) =>
                                       {
                                           cliente.Endereco = endereco;
                                           return cliente;
                                       }, splitOn: "IdEndereco");

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return clientes;
            }
        }

        public void RemoverCliente(Guid idCliente)
        {
            using (IDbConnection con = Connection)
            {
                string sqlRemoverEndereco = @"DELETE FROM T_ENDERECO
                                                WHERE ID_ENDERECO = @IdEndereco";

                string sqlRemoverCliente = @"DELETE FROM T_CLIENTE
                                                WHERE CD_CLIENTE = @IdCliente";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("IdEndereco", idCliente, DbType.Guid, ParameterDirection.Input);

                    con.Execute(sqlRemoverEndereco, param: parametros);
                    con.Execute(sqlRemoverCliente, param: parametros);
                }
                catch
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
