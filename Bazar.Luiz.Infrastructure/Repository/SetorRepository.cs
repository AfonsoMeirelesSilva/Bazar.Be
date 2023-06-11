using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Infrastructure.Context;

namespace Bazar.Luiz.Infrastructure.Repository
{
    public class SetorRepository : BaseRepository<Setor>, ISetorRepository
    {
        public SetorRepository(IDbContext dapper) : base(dapper)
        { }

    }
}
