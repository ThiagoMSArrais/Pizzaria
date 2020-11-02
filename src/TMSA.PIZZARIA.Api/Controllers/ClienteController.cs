using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TMSA.PIZZARIA.Api.DTO;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes;
using TMSA.PIZZARIA.Cadastro.Domain.Clientes.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMSA.PIZZARIA.Api.Controllers
{
    [Route("api/[controller]")]
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


        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<ClienteDto> Get()
        {
            return _mapper.Map<IEnumerable<ClienteDto>>(_clienteServices.ObterClientes());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
