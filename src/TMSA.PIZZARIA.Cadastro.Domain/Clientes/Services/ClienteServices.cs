using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;

namespace TMSA.PIZZARIA.Cadastro.Domain.Clientes.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _clienteRepository.AtualizarCliente(cliente);
        }

        public void CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.CadastrarCliente(cliente);
        }

        public Cliente ObterClientePorId(Guid idCliente)
        {
            return _clienteRepository.ObterClientePorId(idCliente);
        }

        public Cliente ObterClientePorTelefone(string telefone)
        {
            return _clienteRepository.ObterClientePorTelefone(telefone);
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            return _clienteRepository.ObterClientes();
        }

        public void RemoverCliente(Guid idCliente)
        {
            _clienteRepository.RemoverCliente(idCliente);
        }
    }
}
