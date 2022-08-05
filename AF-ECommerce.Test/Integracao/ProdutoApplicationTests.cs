using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AF_ECommerce.Test.Integracao
{
    public class ProdutoApplicationTests
    {

        [Fact(DisplayName = "PedidoApllication - Verificar Metodo Estoque(Produto)")] //DisplayName = Como vai aparecer na aba TestExplore ( Nome Do serviço que estou testando - Nome do metodo que vou testar)
        [Trait("Application", "PedidoApplication")] //Organizar exibição (Categoria (ou tbm camada) - Nome) 
        public async Task DadoQueQaunatidadeMenorQueEstoque_PodeDebitar()
        {
            await Task.Delay(1);
            //Arrange
            var produto = new Produto();
            produto.Estoque = 5;

            //Act        

            var resultado = produto.VerificarSePodeDebitarEstoque(3);

            //Assert 


            Assert.True(resultado);

        }
    }
}
