using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Produtos.Api.Controllers._Base;
using Produtos.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Produtos.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : BaseApiController
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IHttpContextAccessor contextAcessor, IProdutoAppService produtoAppService)
            : base(contextAcessor)
        {
            _produtoAppService = produtoAppService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _produtoAppService.GetAll();

            if (resultado == null || !resultado.Any())
                return NotFound("Nenhum item encontrado");

            return Ok(resultado);
            //return new string[] { "value1", "value2" };
        }

        //// GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(long id)
        //{
        //    var produto = _produtoAppService.GetById(id);

        //    if (produto != null)
        //    {
        //        return Ok(produto);
        //    }

        //    return NotFound("Nenhum pedido encontrado");
        //}

        // GET api/<ProductsController>/7894561312
        [HttpGet("{upc}")]
        public IActionResult GetByUpc(string upc)
        {
            var produto = _produtoAppService.ObterProdutoPorUpc(upc);

            if (produto != null)
            {
                return Ok(produto);
            }

            return NotFound("Nenhum pedido encontrado");
        }
        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
