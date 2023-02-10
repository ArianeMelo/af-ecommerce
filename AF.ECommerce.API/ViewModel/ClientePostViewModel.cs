
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
    public class ClientePostViewModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("rg")]
        public string Rg { get; set; }

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

        public class ClientePostViewModelValidation : AbstractValidator<ClientePostViewModel>
        {
            public ClientePostViewModelValidation()
            {
                RuleFor(cliente => cliente.Nome)
                      .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(cliente => cliente.Cpf)
                     .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(cliente => cliente.Rg)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(cliente => cliente.Telefone)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Cep)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Endereco)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Numero)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThan(0).WithMessage(MensagemErro.erroNumeroInvalido);

                RuleFor(pedido => pedido.Cidade)
                .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.Estado)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

            }

        }

        public bool EstiverValido()
        {
            ValidationResult = new ClientePostViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
