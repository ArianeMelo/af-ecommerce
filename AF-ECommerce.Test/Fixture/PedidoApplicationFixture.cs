using AF.ECommerce.API.Factory;
using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Application;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF_ECommerce.Test.Fixture
{
    public class PedidoApplicationFixture
    {
        private Mock<ILogger<PedidoApplication>> _loggerMock;
        public Mock<IPedidoRepository> PedidoRepositoryMock { get; set; }
        public Mock<IProdutoRepository> ProdutoRepositoryMock { get; set; }
        public Mock<IPedidoItemRepository> PedidoItemRepositoryMock { get; set; }

        public Mock<Produto> ProdutoUm { get; set; } = new Mock<Produto>();
        public Mock<Produto> ProdutoDois { get; set; } = new Mock<Produto>();

        public PedidoApplication SetupPedidoApplicationSucesso()
        {

            CarregarMock();

            ProdutoUm = RetonarProdutoUm().Result;
            ProdutoDois = RetonarProdutoDois().Result;

            ProdutoUm
                .Setup(p => p.VerificarSePodeDebitarEstoque(It.IsAny<int>()))
                .Returns(true);

            ProdutoDois
               .Setup(p => p.VerificarSePodeDebitarEstoque(It.IsAny<int>()))
               .Returns(true);

            ProdutoRepositoryMock
                .Setup(produRep => produRep.ObterPorId(Guid.Parse("5205aa45-adbc-4d59-a535-833784285236")))
                .Returns(Task.FromResult(ProdutoUm.Object));

            ProdutoRepositoryMock
              .Setup(produRep => produRep.ObterPorId(Guid.Parse("21123148-2d52-4d4c-a6bc-a5a5ed0d660a")))
              .Returns(Task.FromResult(ProdutoDois.Object));

            ProdutoUm
                .Setup(p => p.DebitarEstoque(It.IsAny<int>()))
                .Callback((int value) => DebitarEstoqueProdutoUm(value));

            ProdutoDois
               .Setup(p => p.DebitarEstoque(It.IsAny<int>()))
               .Callback((int value) => DebitarEstoqueProdutoDois(value));



            return new PedidoApplication(
                PedidoRepositoryMock.Object,
                ProdutoRepositoryMock.Object,
                PedidoItemRepositoryMock.Object,
                _loggerMock.Object);
        }       

        private void CarregarMock()
        {
            _loggerMock = new Mock<ILogger<PedidoApplication>>();
            PedidoRepositoryMock = new Mock<IPedidoRepository>();
            ProdutoRepositoryMock = new Mock<IProdutoRepository>();
            PedidoItemRepositoryMock = new Mock<IPedidoItemRepository>();
        }
        public Pedido ObterPedidoValido()
        {
            var pedidoJson = System.IO.File.ReadAllText("JsonMock/Pedido.json");

            var pedido = JsonConvert.DeserializeObject<Pedido>(pedidoJson);

            return pedido;
        }


        public async Task<Mock<Produto>> RetonarProdutoUm()
        {
            await Task.Delay(1);

            var produto = new Mock<Produto>();
            produto.Object.Estoque = 10;
            produto.Object.Id = Guid.Parse("5205aa45-adbc-4d59-a535-833784285236");

            return produto;
        }

        public async Task<Mock<Produto>> RetonarProdutoDois()
        {
            await Task.Delay(1);

            var produto = new Mock<Produto>();
            produto.Object.Estoque = 10;
            produto.Object.Id = Guid.Parse("21123148-2d52-4d4c-a6bc-a5a5ed0d660a");

            return produto;
        }       

        public void DebitarEstoqueProdutoUm(int inteiro)
        {
            ProdutoUm.Object.Estoque -= inteiro;
        }

        public void DebitarEstoqueProdutoDois(int inteiro)
        {
            ProdutoUm.Object.Estoque -= inteiro;
        }

    }
}
