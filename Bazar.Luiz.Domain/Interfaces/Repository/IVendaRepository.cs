using Bazar.Luiz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar.Luiz.Domain.Interfaces.Repository
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        Task<IEnumerable<Venda>> GetVendasComProdutos();
    }
}
