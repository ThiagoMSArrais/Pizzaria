using System;
using System.Collections.Generic;

namespace TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces
{
    public interface IClienteRepository
    {
        void CadastrarCliente(Cliente cliente);
        IEnumerable<Cliente> ObterClientes();
        Cliente ObterClientePorId(Guid idCliente);
        Cliente ObterClientePorTelefone(string telefone);
        void AtualizarCliente(Cliente cliente);
        void RemoverCliente(Guid idCliente);
    }
}
