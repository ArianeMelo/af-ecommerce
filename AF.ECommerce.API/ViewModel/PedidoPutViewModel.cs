using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Enum;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.ViewModel
{
    public class PedidoPutViewModel
    {      

        [JsonProperty("cliente_id")]
        public Guid ClienteId { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("observacao")]
        public string Observacao { get; set; }

        public ValidationResult ValidationResult { get; private set; }
        public class PedidoPutViewModelValidation : AbstractValidator<PedidoPutViewModel>
        {
            public PedidoPutViewModelValidation()            {
               
                RuleFor(pedidoValidation => pedidoValidation.ClienteId)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .NotEqual(Guid.Empty).WithMessage(MensagemErro.erroClienteNaoCadastrado);

                RuleFor(pedidoValidation => pedidoValidation.Valor)
                    .GreaterThan(0).WithMessage("No campo {PropertyName}" + MensagemErro.erroNumeroInvalido);

            }
        }
        public bool EstiverValido()
        {
            ValidationResult = new PedidoPutViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

}

