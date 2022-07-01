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
    public class PedidoItemPutViewModel
    {

        [JsonProperty("pedido_id")]
        public Guid PedidoId { get; set; }

        [JsonProperty("produto_id")]
        public Guid ProdutoId { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("desconto")]
        public decimal? Desconto { get; set; }

        public ValidationResult ValidationResult { get; set; }


        public class PedidoItemPustViewModelValidation : AbstractValidator<PedidoItemPutViewModel>

        {
            public PedidoItemPustViewModelValidation()
            {
                RuleFor(pedidoItem => pedidoItem.PedidoId)
                       .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                       .NotEqual(Guid.Empty).WithMessage(MensagemErro.erroPedidoNaoCadastrado);

                RuleFor(pedidoItem => pedidoItem.ProdutoId)
                     .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                     .NotEqual(Guid.Empty).WithMessage("Id produto inválido ou não cadastrado");

                RuleFor(pedidoItem => pedidoItem.Quantidade)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThanOrEqualTo(0).WithMessage(MensagemErro.erroNumeroInvalido);

                RuleFor(pedido => pedido.Valor)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThanOrEqualTo(0).WithMessage(MensagemErro.erroNumeroInvalido);

                RuleFor(pedido => pedido.Desconto)
                    .GreaterThanOrEqualTo(0).WithMessage(MensagemErro.erroNumeroInvalido);

            }

        }

        public bool EstiverValido()
        {
            ValidationResult = new PedidoItemPustViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
