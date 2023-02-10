using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Queries
{
    public static class PedidoQuery
    {
        public static string ObterPedidoPorId =
            @"SELECT" +
                                           " P.ID, P.CLIENTEID," +
                                           " P.DATACADASTRO, P.TIPOFRETE,  P.STATUS, P.VALOR, P.OBSERVACAO, " +
                                           " IP.ID AS ID_ITEM_PEDIDO, IP.PEDIDO_ID AS PedidoId, IP.PRODUTO_ID AS ProdutoId, IP.QUANTIDADE, IP.VALOR, IP.DESCONTO " +
                           "FROM" +
                                           " PEDIDOS as P " +
                           "INNER JOIN " +
                                           "PEDIDOS_ITEM as IP " +
                            "ON   " +
                                           "P.ID = IP.PEDIDO_ID WHERE P.ID = @id ";

        public static string ObterTodosOsPedidos =
            @"SELECT" +
                                           " P.ID, P.CLIENTEID," +
                                           " P.DATACADASTRO, P.TIPOFRETE,  P.STATUS, P.VALOR, P.OBSERVACAO, " +
                                           " IP.ID AS ID_ITEM_PEDIDO, IP.PEDIDO_ID AS PedidoId, IP.PRODUTO_ID AS ProdutoId, IP.QUANTIDADE, IP.VALOR, IP.DESCONTO " +
                           "FROM" +
                                           " PEDIDOS as P " +
                           "INNER JOIN " +
                                           "PEDIDOS_ITEM as IP " +
                            "ON   " +
                                           "IP.PEDIDO_ID = P.ID ";
    }
}
