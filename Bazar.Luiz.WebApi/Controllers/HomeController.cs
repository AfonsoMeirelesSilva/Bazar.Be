using Bazar.Luiz.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bazar.Luiz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ISetorService _setorService)
        {
            var setores = await _setorService.GetAllAsync();
            foreach(var setor in setores)
            {
                Console.WriteLine(setor.Id+" "+setor.Descricao.ToUpper());
            }
            return Ok(setores);
        }
    }
}
