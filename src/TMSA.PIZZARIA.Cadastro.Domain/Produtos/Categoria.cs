using FluentValidation;
using System;
using TMSA.PIZZARIA.Domain.Core.Models;

namespace TMSA.PIZZARIA.Cadastro.Domain.Produtos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid idCategoria, string tipo)
        {
            IdCategoria = idCategoria;
            Tipo = tipo;
        }

        public Guid IdCategoria { get; private set; }
        public string Tipo { get; private set; }


        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarTipo();
        }

        private void ValidarTipo()
        {
            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("Obrigatório um tipo de categoria")
                .Length(3, 50).WithMessage("Obrigatório no mínimo 3 caracteres a 50 caracteres.");
        }
        #endregion
    }
}
