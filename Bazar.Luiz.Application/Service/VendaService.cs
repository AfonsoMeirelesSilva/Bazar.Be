using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar.Luiz.Application.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        public async Task<IEnumerable<Venda>> VendaComProdutosAsync()
        {
            var response = await _vendaRepository.GetVendasComProdutos();
            return response;
        }
    }
}
