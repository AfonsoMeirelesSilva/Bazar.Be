using Bazar.Luiz.Domain.Entities;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Infrastructure.Context;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar.Luiz.Infrastructure.Repository
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        private readonly IDbContext _dapper;
        public VendaRepository(IDbContext dapper) : base(dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<Venda>> GetVendasComProdutos()
        {
        const string sql = @"
                            SELECT 
                                V.Id,
                                V.ValorVenda as ValorVenda,
                                V.Descricao,
                                V.DataVenda,
                                V.Desconto,
                                V.Acrescimo,
                                V.Status,
                                PV.IdProduto,
                                PV.Quantidade,
                                PV.ValorProduto,
                                PV.DataCriacao,
                                P.Nome,
                                P.CodigoBarras
                            FROM Venda V
                            JOIN ProdutoVenda PV ON PV.IdVenda = V.Id
                            JOIN Produto P ON P.Id = PV.IdProduto";

            var vendasComProdutos = await _dapper.Connection.QueryAsync<Venda, Produto, Venda>(sql,
            (venda, produto) => {
            venda.Produtos ??= new List<Produto>();
            venda.Produtos.Add(produto);
            return venda;
            },splitOn: "IdProduto");

        var a = vendasComProdutos
                .GroupBy(v => v.Id)
                .Select(g => new Venda
                {
                    Id = g.Key,
                    Descricao = "ASDASD",
                    Produtos = g.SelectMany(v => v.Produtos).ToList()
                })
                .ToList();
            return a;
        }
    }
}
