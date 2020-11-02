using FluentValidation;
using System;
using TMSA.PIZZARIA.Domain.Core.Models;

namespace TMSA.PIZZARIA.Cadastro.Domain.Clientes
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(
            Guid idEndereco,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string estado,
            string cep)
        {
            IdEndereco = idEndereco;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public Guid IdEndereco { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumeroEndereco();
            ValidarBairro();
            ValidarCidade();
            ValidarEstado();
            ValidarCep();
        }

        private void ValidarLogradouro()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("Obrigatório informar o logradouro.")
                .Length(3, 150).WithMessage("Obrigatório no mínimo 3 caracteres a 150 caracteres.");
        }

        private void ValidarNumeroEndereco()
        {
            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("Obrigatório informar um número.")
                .Length(1, 10).WithMessage("Obrigatório no mínimo 1 caracteres a 10 caracteres.");
        }

        private void ValidarBairro()
        {
            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("Obrigatório informar o bairro.")
                .Length(3, 50).WithMessage("Obrigatório no mínimo 3 caracteres a 50 caracteres.");
        }

        private void ValidarCidade()
        {
            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("Obrigatório informar a cidade.")
                .Length(3, 50).WithMessage("Obrigatório no mínimo 3 caracteres a 50 caracteres.");
        }

        private void ValidarEstado()
        {
            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("Obrigatório informar o estado.")
                .Length(3, 50).WithMessage("Obrigatório no mínimo 3 caracteres a 50 caracteres.");
        }

        private void ValidarCep()
        {
            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("Obrigatório informar o Cep.")
                .Length(8, 8).WithMessage("Obrigatório 8 caracteres.");
        }

        #endregion
    }
}
