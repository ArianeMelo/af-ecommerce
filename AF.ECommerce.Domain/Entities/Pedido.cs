using AF.ECommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class Pedido : Entity
    {
        public Guid ClienteId { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public Status Status { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();

        public Pedido()
        { }

        public Pedido(Guid clienteId, TipoFrete tipoFrete, string observacao = "")
        {           
            DataCadastro = DateTime.Now;
            Status = Status.EmAnalise;
            Observacao = observacao;
            TipoFrete = tipoFrete;
            ClienteId = clienteId;
        }

        public void AdicionarItem(PedidoItem item)
        {
            this.Itens.Add(item);

            CalcularValor();
        }
     
        public void CalcularValor()
        {
            Valor = 0;
            foreach (var item in Itens)
            {
                //Valor do Pedido
                Valor += (item.Valor * item.Quantidade) - item.Desconto ;
            }  
        }

        public void AlterarStatusParaProcessando()
        {
            Status = Status.EmProcessamento;
        }

        public void AlterarStatusParaEntregue()
        {
            Status = Status.Entregue;
        }
    }
}
