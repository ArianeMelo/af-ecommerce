using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class MensagemErro
    {     

        public static string  erroStringVazio = " deve ser preenchido";

        public static string erroNumeroInvalido = " informar um número maior que zero";

        public static string erroDadoExistente = " já está cadastrado";

        public static string erroDadoNaoCadastrado = " não cadastrado";

        public static string erroPedidoNaoCadastrado = " Id do Pedido inválido ou não está cadastrado";

        public static string erroClienteNaoCadastrado = " Id do Cliente inválido ou não está cadastrado";

        public static string erroCategoriaNaoCadastrada = " Id da Categoria inválida ou não está cadastrada";

        public static string erroDescCategoriaNaoCadastrada = " Descrição informada inválida ou não está cadastrada";

        public static string erroPedidoItemNaoCadastrado= " Id informado é inválido ou não está cadastrado";

        public static string erroProdutoNaoCadastrado = " Id do Produto inválido ou não está cadastrado";
    }

}
