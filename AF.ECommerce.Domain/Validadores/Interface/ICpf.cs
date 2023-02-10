using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Validadores.Interface
{
    public interface ICpf
    {
        bool ValidarCpf(string cpf);
    }
}
