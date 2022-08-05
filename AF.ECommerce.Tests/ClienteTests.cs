using AF.ECommerce.Application;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Validadores.Classe;
using AF.ECommerce.Domain.Validadores.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AF.ECommerce.Tests
{
    public class ClienteTests
    {
        private Mock<ICep> _cepMock;
        private Mock<ICpf> _cpfMock;
        private Mock<IClienteApplication> _clienteApplicationMock;

        public ClienteTests()
        {
            _cepMock = new Mock<ICep>();
            _cpfMock = new Mock<ICpf>();
            _clienteApplicationMock = new Mock<IClienteApplication>();
        }

        [Theory]
        [InlineData(08255-120)]
        [InlineData(00255-120)]
        [InlineData(01449-001)]
        [InlineData(00449-001)]
        
        public async Task VerificarCep_RetornarSucessoQuandoOCepExistirEForDigitadoCorretamente(string cpf)
        {
            var cep = new Cep();

            //Act
            var cepEValido =  cep.ValidarCep(cpf);


            //Assert

            var teste = cepEValido;


        }

    }
}
