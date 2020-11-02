using FluentValidation;
using TMSA.PIZZARIA.Domain.Core.Models;

namespace TMSA.PIZZARIA.Cadastro.Domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {
        public Cliente(
            string nome, 
            string telefone, 
            Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; set; }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarTelefone();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Obrigatório um nome.")
                .Length(3, 70).WithMessage("Obrigatório no mínimo 3 caracteres a 70 caracteres.");
        }

        private void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Obrigatório um telefone.")
                .Length(11, 11).WithMessage("Obrigatório DDD + Telefone.");
        }
        #endregion
    }
}
