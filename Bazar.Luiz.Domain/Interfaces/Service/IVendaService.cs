using Bazar.Luiz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar.Luiz.Domain.Interfaces.Service
{
    public interface IVendaService
    {
        Task<IEnumerable<Venda>> VendaComProdutosAsync();

    }
}
