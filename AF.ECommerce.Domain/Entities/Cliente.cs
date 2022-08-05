using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AF.ECommerce.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public Cliente()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

	}
}   
		



