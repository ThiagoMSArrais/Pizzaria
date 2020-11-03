using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Api.DTO;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMSA.PIZZARIA.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServices clienteServices,
                                 IMapper mapper)
        {
            _clienteServices = clienteServices;
            _mapper = mapper;
        }


        // GET: api/V1.0/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(_clienteServices.ObterClientes()));
        }

        // GET api/V1.0/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_mapper.Map<ClienteDto>(_clienteServices.ObterClientePorId(id)));
        }

        [HttpGet]
        [Route("ObterPorTelefone/{telefone}")]
        public IActionResult ObterPorTelefone(string telefone)
        {
            return Ok(_mapper.Map<ClienteDto>(_clienteServices.ObterClientePorTelefone(telefone)));
        }

        // POST api/V1.0/<ClienteController>
        [HttpPost]
        public void Post([FromBody] ClienteDto cliente)
        {
            _clienteServices.CadastrarCliente(_mapper.Map<Cliente>(cliente));
        }

        // PUT api/V1.0/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] ClienteDto cliente)
        {
            _clienteServices.AtualizarCliente(_mapper.Map<Cliente>(cliente));
        }

        // DELETE api/V1.0/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _clienteServices.RemoverCliente(id);
        }
    }
}
