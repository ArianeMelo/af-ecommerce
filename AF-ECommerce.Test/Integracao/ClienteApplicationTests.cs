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
    [Collection(nameof(ClienteApplicationCollection))]
    public class ClienteApplicationTests
    {
        private ClienteApplicationFixture _clienteApplicationFixture;

        public ClienteApplicationTests(ClienteApplicationFixture clienteApplicationFixture)
        {
            _clienteApplicationFixture = clienteApplicationFixture;
        }


        [Fact(DisplayName = "ClienteApplication - AdicionarCliente com sucesso")] //DisplayName = Como vai aparecer na aba TestExplore ( Nome Do serviço que estou testando - Nome do metodo que vou testar)
        [Trait("Application", "ClienteApplication")] //Organizar exibição (Categoria (ou tbm camada) - Nome) 
        public async Task ClienteApplication_DadoCLienteValido_AdicionaComSucesso()
        {
            //Arrange
            var cliente = _clienteApplicationFixture.ObterClienteValido();

            var clienteApplication = _clienteApplicationFixture.SetupPedidoApplicationSucesso();
          
            //Act

            var resultado = await clienteApplication.Adicionar(cliente);
                      

            //Asset

            Assert.True(resultado);           

            _clienteApplicationFixture.CpfMock
             .Verify(c => c.ValidarCpf(It.IsAny<string>()), Times.Exactly(1));

            Assert.True(cliente.Cpf.Equals("906.048.780-01"));                  

            _clienteApplicationFixture.CepMock
               .Verify(c => c.ValidarCep(It.IsAny<string>()), Times.Exactly(1));

            Assert.True(cliente.Cep.Equals("08255-120"));
              


        }

    }
}
