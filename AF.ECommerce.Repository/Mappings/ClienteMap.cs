using AF.ECommerce.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Mappings
{
    public class ClienteMap : DommelEntityMap<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Clientes");
            Map(cliente => cliente.Id).ToColumn("Id").IsKey();
            Map(cliente => cliente.Nome).ToColumn("Nome");
            Map(cliente => cliente.Cpf).ToColumn("Cpf");
            Map(cliente => cliente.Rg).ToColumn("Rg");
            Map(cliente => cliente.Telefone).ToColumn("Telefone");
            Map(cliente => cliente.Endereco).ToColumn("Endereco");
            Map(cliente => cliente.Numero).ToColumn("Numero");
            Map(cliente => cliente.Cidade).ToColumn("Cidade");
            Map(cliente => cliente.Estado).ToColumn("Estado");
            Map(cliente => cliente.Cep).ToColumn("Cep");
            Map(cliente => cliente.DataCadastro).ToColumn("Data_Cadastrado");
        }

    }
}
