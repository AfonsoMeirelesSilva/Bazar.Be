using System;

namespace Bazar.Luiz.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int Ativo { get; set; }
    }
}
