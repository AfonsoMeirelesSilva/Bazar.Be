using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Luiz.Application.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _produtoRepository.GetAllActiveAsync();
        }
    }
}
