using AF.ECommerce.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Mappings
{
    public class ProdutoMap : DommelEntityMap<Produtos>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            Map(produto => produto.Id).ToColumn("Id").IsKey();
            Map(produto => produto.CategoriaId).ToColumn("Categoria_Id");
            Map(produto => produto.Codigo).ToColumn("Codigo");
            Map(produto => produto.Descricao).ToColumn("Descricao");
            Map(produto => produto.Valor).ToColumn("Valor");
            Map(produto => produto.TipoProduto).ToColumn("Tipo_Produto");
            Map(produto => produto.Estoque).ToColumn("Estoque");
            Map(produto => produto.Ativo).ToColumn("Ativo");
        }
    }
}
