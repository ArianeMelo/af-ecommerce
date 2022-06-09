using AF.ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class Pedidos
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public Status Status { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }

        public Pedidos()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }
}
