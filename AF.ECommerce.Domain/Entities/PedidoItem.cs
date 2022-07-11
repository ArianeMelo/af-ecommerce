using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class PedidoItem
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }

        public PedidoItem(
            Guid pedidoId,
            Guid produtoId,
            int quantidade,
            decimal valor,
            decimal desconto)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
        }
    }
}
