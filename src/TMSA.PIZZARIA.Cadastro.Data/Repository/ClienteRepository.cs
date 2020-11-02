using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;

namespace TMSA.PIZZARIA.Cadastro.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterClientePorId(Guid idCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterClientePorTelefone(string telefone)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            throw new NotImplementedException();
        }

        public void RemoverCliente(Guid idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
