using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TMSA.PIZZARIA.Api.DTO;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos;
using TMSA.PIZZARIA.Cadastro.Domain.Produtos.Interfaces;

namespace TMSA.PIZZARIA.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoServices _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoServices produtoService,
                                  IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        #region Produtos
        // GET: api/V1.0/<ProdutosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(_produtoService.ObterProdutos()));
        }

        // GET api/V1.0/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_mapper.Map<ProdutoDto>(_produtoService.ObterProdutoPorId(id)));
        }

        // POST api/V1.0/<ProdutosController>
        [HttpPost]
        public void Post([FromBody] ProdutoDto produtoDto)
        {
            _produtoService.CadastrarProduto(_mapper.Map<ProdutoDto, Produto>(produtoDto));
        }

        // PUT api/V1.0/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] ProdutoDto produtoDto)
        {
            _produtoService.AtualizarProduto(_mapper.Map<ProdutoDto, Produto>(produtoDto));
        }

        // DELETE api/V1.0/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoService.RemoverProduto(id);
        }

        // GET api/V1.0/<ProdutosController>/ObterprodutoPorCategoria/5
        [HttpGet]
        [Route("ObterprodutoPorCategoria/{id}")]
        public IActionResult ObterprodutoPorCategoria(Guid id)
        {
            return Ok(_mapper.Map<ProdutoDto>(_produtoService.ObterprodutoPorCategoria(id)));
        }
        #endregion

        #region Categorias
        // GET api/V1.0/<ProdutosController>/Categorias
        [HttpGet]
        [Route("Categorias")]
        public IActionResult ObterCategorias()
        {
            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(_produtoService.ObterCategorias()));
        }

        // GET api/V1.0/<ProdutosController>/Categorias/5
        [HttpGet]
        [Route("Categorias/{id}")]
        public IActionResult ObterCategoriaPorId(Guid id)
        {
            return Ok(_mapper.Map<CategoriaDto>(_produtoService.ObterCategoriaPorId(id)));
        }

        // POST api/V1.0/<ProdutosController>/Categorias
        [HttpPost]
        [Route("Categorias")]
        public void Post([FromBody] CategoriaDto categoriaDto)
        {
            _produtoService.CadastrarCategoria(_mapper.Map<CategoriaDto, Categoria>(categoriaDto));
        }

        // PUT api/V1.0/<ProdutosController>/Categorias/
        [HttpPut]
        [Route("Categorias")]
        public void Put([FromBody] CategoriaDto categoriaDto)
        {
            _produtoService.AtualizarCategoria(_mapper.Map<CategoriaDto, Categoria>(categoriaDto));
        }

        // DELETE api/V1.0/<ProdutosController>/Categorias/Remover/5
        [HttpDelete]
        [Route("Categorias/Remover/{id}")]
        public void RemoverCategoria(Guid id)
        {
            _produtoService.RemoverCategoria(id);
        }
        #endregion
    }
}
