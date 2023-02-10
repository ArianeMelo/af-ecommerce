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
    public class CategoriaPostViewModel
    {
        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public class CategoriaPostViewModelValidation : AbstractValidator<CategoriaPostViewModel>
        {
            public CategoriaPostViewModelValidation()
            {
                RuleFor(categoriaValidation => categoriaValidation.Descricao)
                    .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .Length(4).WithMessage("O campo {PropertyName} deve possuir mais que 4 caracteres ");
            }
        }

        public bool EstiverValido()
        {
            ValidationResult = new CategoriaPostViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

