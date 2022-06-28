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
    public class CategoriaPutViewModel
    {
        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public class CategoriaPutViewModelValidation : AbstractValidator<CategoriaPutViewModel>
        {
            public CategoriaPutViewModelValidation()
            {
                RuleFor(categoria => categoria.Descricao)
                     .NotNull().WithMessage("O campo {PropertyName}" + MensagemErro.erroStringVazio)
                    .Length(4).WithMessage("O campo {PropertyName} deve possuir mais que 4 caracteres ");
            }
        }

        public bool EstiverValido()
        {
            ValidationResult = new CategoriaPutViewModelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
