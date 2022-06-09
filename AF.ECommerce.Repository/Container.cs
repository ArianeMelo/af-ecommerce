using AF.ECommerce.Repository.Mappings;
using Dapper.FluentMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository
{
    public static class Container
    {
        public static void RegistrarMapeamentoDapper()
        {
            FluentMapper.Initialize(configurar =>
            {
                configurar.AddMap(new ClienteMap());
                configurar.AddMap(new ProdutoMap());
                configurar.AddMap(new PedidoMap());
                configurar.AddMap(new CategoriaMap());
                configurar.AddMap(new PedidoItemMap());
            });
        }
    }
}
