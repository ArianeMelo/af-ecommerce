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
    public class ProdutoPostViewModel
    {
        [JsonProperty("categoria_id")]
        public Guid CategoriaId { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("tipo_produto")]
        public TipoProduto TipoProduto { get; set; }

        [JsonProperty("estoque")]
        public int Estoque { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public class ProdutoPostViewModelValidation : AbstractValidator<ProdutoPostViewModel>
        {

            public ProdutoPostViewModelValidation()
            {
                RuleFor(produto => produto.CategoriaId)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .NotEqual(Guid.Empty).WithMessage( MensagemErro.erroProdutoNaoCadastrado);

                RuleFor(produto => produto.Codigo)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(produto => produto.Descricao)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .MinimumLength(20).MaximumLength(200).WithMessage("A Descrição deve conter emtntre 20 e 200 caracteres");

                RuleFor(produto => produto.Valor)
                 .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                 .GreaterThan(0).WithMessage("No campo {PropertyName}" +  MensagemErro.erroNumeroInvalido);

                RuleFor(produto => produto.TipoProduto)
                    .NotNull().WithMessage("Informar qual o tipo do Produto")
                    .IsInEnum();

                RuleFor(produto => produto.Estoque)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .GreaterThan(1).WithMessage("Deve existir no mínimo 2 produtos em estoque");

                RuleFor(produto => produto.Ativo)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);

                RuleFor(produto => produto.Estoque)
                .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                .GreaterThan(0).WithMessage("No campo {PropertyName}" + MensagemErro.erroNumeroInvalido);

                RuleFor(produto => produto.Ativo)
                .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio);


            }
        }

        public bool EstiverValido()
        {
            ValidationResult = new ProdutoPostViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
