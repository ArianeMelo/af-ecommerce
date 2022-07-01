using AF.ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
