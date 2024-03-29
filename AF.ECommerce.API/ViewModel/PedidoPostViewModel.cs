﻿using AF.ECommerce.Domain.Entities;
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
    public class PedidoPostViewModel
    {

        [JsonProperty("cliente_id")]
        public Guid ClienteId { get; set; }

        [JsonProperty("tipo_frete")]
        public TipoFrete TipoFrete { get; set; }

        [JsonProperty("observacao")]
        public string Observacao { get; set; }

        [JsonProperty("itens")]
        public List<PedidoItemPostViewModel> Itens { get; set; }

        public ValidationResult ValidationResult { get; private set; }
        public class PedidoPostViewModelValidation : AbstractValidator<PedidoPostViewModel>
        {
            public PedidoPostViewModelValidation()
            {
                RuleFor(pedido => pedido.ClienteId)
                  .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                  .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(pedido => pedido.TipoFrete)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .IsInEnum();
            }
        }
        public bool EstiverValido()
        {
            ValidationResult = new PedidoPostViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
