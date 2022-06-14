using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Categoria()
        {
            Id = Guid.NewGuid();
        }

    }
}
