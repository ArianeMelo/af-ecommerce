using AF.ECommerce.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.ViewModel
{
    public class ClientePutViewModel
    {           
        
        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public class ClientePutViewModelValidation : AbstractValidator<ClientePutViewModel>
        {
            public ClientePutViewModelValidation()
            {               

                RuleFor(cliente => cliente.Telefone)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Cep)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Endereco)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Numero)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Cidade)
                .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Estado)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

            }

        }

        public bool EstiverValido()
        {
            ValidationResult = new ClientePutViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }

    }

}

