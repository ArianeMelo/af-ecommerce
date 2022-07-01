﻿using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IPedidoItemRepository
    {
        Task<IEnumerable<PedidoItem>> ObterTodos();
        Task<PedidoItem> ObterPorId(Guid id);
        Task Adicionar(PedidoItem pedidoItem);
        Task Alterar(PedidoItem pedidoItem);
        Task Excluir(PedidoItem pedidoItem);
    }
}
