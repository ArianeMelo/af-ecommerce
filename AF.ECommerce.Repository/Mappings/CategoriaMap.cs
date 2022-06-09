using AF.ECommerce.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Mappings
{
    public class CategoriaMap : DommelEntityMap<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categorias");
            Map(categoria => categoria.Id).ToColumn("Id").IsKey();
            Map(categoria => categoria.Descricao).ToColumn("Descricao");
        }
    }
}
