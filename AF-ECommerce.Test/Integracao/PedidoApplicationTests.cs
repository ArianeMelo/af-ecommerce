using AF.ECommerce.Domain.Entities;
using AF_ECommerce.Test.Collections;
using AF_ECommerce.Test.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AF_ECommerce.Test.Integracao
{

    [Collection(nameof(PedidoApplicationCollection))]
    public class PedidoApplicationTests
    {
        private PedidoApplicationFixture _pedidoApplicationFixture;

        public PedidoApplicationTests(PedidoApplicationFixture pedidoApplicationFixture)
        {
            _pedidoApplicationFixture = pedidoApplicationFixture;
        }

        [Fact(DisplayName = "PedidoApplication - AdicionarPedido com sucesso")] //DisplayName = Como vai aparecer na aba TestExplore ( Nome Do serviço que estou testando - Nome do metodo que vou testar)
        [Trait("Application", "PedidoApplication")] //Organizar exibição (Categoria (ou tbm camada) - Nome) 

        public async Task PedidoApplication_DadoQuePedidoValido_AdicionarComSucesso()
        {
            //Arrange = Faz o que precisa para o teste ocorrer 

            var pedido = _pedidoApplicationFixture.ObterPedidoValido();

            var pedidoApplication = _pedidoApplicationFixture.SetupPedidoApplicationSucesso();

            //Act = Onde ocorre ação 

            var resultado = await pedidoApplication.AdicionarPedido(pedido);

            //Assert = Valida se ocorreu do jeito correto

            //Assert.True(resultado);        

            _pedidoApplicationFixture.ProdutoRepositoryMock
                .Verify(produtoRep => produtoRep.ObterPorId(It.IsAny<Guid>()), Times.Exactly(2));

            _pedidoApplicationFixture.ProdutoUm
                .Verify(produto => produto.VerificarSePodeDebitarEstoque(It.IsAny<int>()), Times.Exactly(1));

            _pedidoApplicationFixture.ProdutoDois
              .Verify(produto => produto.VerificarSePodeDebitarEstoque(It.IsAny<int>()), Times.Exactly(1));

            _pedidoApplicationFixture.ProdutoUm
               .Verify(produto => produto.DebitarEstoque(It.IsAny<int>()), Times.Exactly(1));

            _pedidoApplicationFixture.ProdutoDois
              .Verify(produto => produto.DebitarEstoque(It.IsAny<int>()), Times.Exactly(1));


        }

       
    }
}
