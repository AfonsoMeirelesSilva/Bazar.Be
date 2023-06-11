namespace Bazar.Luiz.Domain.Entities
{
    public class ProdutoVenda : Entity
    {
        public int IdVenda { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }

        public float ValorProduto { get; set; }
    }
}
