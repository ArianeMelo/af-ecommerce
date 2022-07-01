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
    public class PedidoItemPostViewModel
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


        public class PedidoItemPostViewModelValidation : AbstractValidator<PedidoItemPostViewModel>
        {
            public PedidoItemPostViewModelValidation()
            {
                RuleFor(pedidoItem => pedidoItem.PedidoId)
                      .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                      .NotEqual(Guid.Empty).WithMessage(MensagemErro.erroPedidoNaoCadastrado);

                RuleFor(pedidoItem => pedidoItem.ProdutoId)
                     .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                     .NotEqual(Guid.Empty).WithMessage(MensagemErro.erroProdutoNaoCadastrado);

                RuleFor(pedidoItem => pedidoItem.Quantidade)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThan(0).WithMessage("No campo {PropertyName}," + MensagemErro.erroNumeroInvalido);

                RuleFor(pedido => pedido.Valor)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThan(0).WithMessage("No campo {PropertyName}," + MensagemErro.erroNumeroInvalido);

                RuleFor(pedido => pedido.Desconto)
                    .GreaterThanOrEqualTo(0).WithMessage("No campo {PropertyName}," + MensagemErro.erroNumeroInvalido);

            }

        }

        public bool EstiverValido()
        {
            ValidationResult = new PedidoItemPostViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
