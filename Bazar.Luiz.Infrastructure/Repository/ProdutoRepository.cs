using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazar.Luiz.Infrastructure.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDbContext dapper) : base(dapper)
        {
        }
    }
}
