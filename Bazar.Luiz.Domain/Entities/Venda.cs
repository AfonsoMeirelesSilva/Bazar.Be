using System;
using System.Collections.Generic;

namespace Bazar.Luiz.Domain.Entities
{
    public class Venda : Entity
    {
        public string Descricao { get; set; }

        public float ValorVenda { get; set; }

        public float Desconto { get; set; }

        public float Acrescimo { get; set; }

        public int Status { get; set; }

        public DateTime DataVenda { get; set; }

        public List<Produto> Produtos { get; set; }

    }
}
