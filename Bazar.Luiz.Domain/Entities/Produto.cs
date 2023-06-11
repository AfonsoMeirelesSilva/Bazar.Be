namespace Bazar.Luiz.Domain.Entities
{
    public class Produto: Entity
    {
        public int IdSetor { get; set; }

        public int IdMedida { get; set; }

        public string CodigoBarras { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public int QuantidadeMinima { get; set; }

        public float ValorCompra { get; set; }

        public float ValorVenda { get; set; }

        public float Lucro { get; set; }
    }
}
