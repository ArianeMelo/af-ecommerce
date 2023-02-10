using AF.ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class Produto : Entity
    {
        public Guid CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }       

        public virtual bool VerificarSePodeDebitarEstoque(int quantidade)
        {
            return Estoque > quantidade;
        }

        public virtual void DebitarEstoque(int quantidade)
        {
            this.Estoque -= quantidade;
        }
    }
}
