using Bazar.Luiz.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazar.Luiz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVendas([FromServices] IVendaService _vendaService)
        {
            var vendas = await _vendaService.VendaComProdutosAsync();
            return Ok(vendas);
        }
    }
}
