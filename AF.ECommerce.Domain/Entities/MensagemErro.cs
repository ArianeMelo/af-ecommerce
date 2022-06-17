using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class MensagemErro
    {     

        public static string  erroStringVazio = " deve ser preenchido";

        public static string erroNumeroInvalido = " informar um número maior que zero";

        public static string erroDadoExistente = " já cadastrado";

        public static string erroDadoNaoCadastrado = " não cadastrado";

        public static string erroPedidoNaoCadastrado = " Id do Pedido inválido ou não cadastrado";

        public static string erroClienteNaoCadastrado = " Id do Cliente inválido ou não cadastrado";



    }

}
