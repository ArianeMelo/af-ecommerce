using AF.ECommerce.Application;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Domain.Validadores.Interface;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF_ECommerce.Test.Fixture
{
    public class ClienteApplicationFixture
    {
        public Mock<IClienteRepository> ClienteRepositoryMock { get; set; }
        public Mock<ICep> CepMock { get; set; }
        public Mock<ICpf> CpfMock { get; set; }
        public Mock<Cliente> ClienteMock { get; set; } = new Mock<Cliente>();


        public ClienteApplication SetupPedidoApplicationSucesso()
       {
            CarregarMock();

            ClienteMock = RetonarCliente().Result;

            CpfMock
                .Setup(c => c.ValidarCpf(It.IsAny<string>()))
                .Returns(true);

            CepMock
                .Setup(ce => ce.ValidarCep(It.IsAny<string>()))
                .Returns(Task.FromResult(ClienteMock.Object));

            return new ClienteApplication(
                ClienteRepositoryMock.Object,
                CepMock.Object,
                CpfMock.Object);
       }

        private void CarregarMock()
        {            
            ClienteRepositoryMock = new Mock<IClienteRepository>();
            CepMock = new Mock<ICep>();
            CpfMock = new Mock<ICpf>();
        }

        public Cliente ObterClienteValido()
        {
            var clienteJson = System.IO.File.ReadAllText("JsonMock/Cliente.json");

            var cliente = JsonConvert.DeserializeObject<Cliente>(clienteJson);

            return cliente;
        }

        public async Task<Mock<Cliente>> RetonarCliente()
        {
            await Task.Delay(1);

            var cliente = new Mock<Cliente>();
            cliente.Object.Cep = "08255-120";
           
            return cliente;
        }

    }
}
