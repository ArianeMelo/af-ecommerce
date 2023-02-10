using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Validadores.Interface
{
    public interface ICep
    {
        Task<Cliente> ValidarCep(string cep);
    }
}
