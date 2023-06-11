using Bazar.Luiz.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bazar.Luiz.Domain.Entities;

namespace Bazar.Luiz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IProdutoService _produtoService)
        {
            var produtos = await _produtoService.GetAllAsync();
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.CodigoBarras + " - " + produto.Nome.ToUpper() +" - "+produto.Quantidade);
            }
            return Ok(produtos);
        }
    }
}
