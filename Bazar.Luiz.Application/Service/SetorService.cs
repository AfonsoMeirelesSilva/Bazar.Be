using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Domain.Interfaces.Service;
using Bazar.Luiz.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar.Luiz.Application.Service
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IDbContext _contexto;
        public SetorService(ISetorRepository setorRepository, IDbContext contexto)
        {
            _setorRepository = setorRepository;
            _contexto = contexto;
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _setorRepository.GetAllActiveAsync();
        }
    }
}
