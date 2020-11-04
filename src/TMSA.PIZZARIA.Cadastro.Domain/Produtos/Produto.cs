using FluentValidation;
using System;
using TMSA.PIZZARIA.Domain.Core.Models;

namespace TMSA.PIZZARIA.Cadastro.Domain.Produtos
{
    public class Produto : Entity<Produto>
    {
        public Produto(Guid idProduto,
                       string nome,
                       string descricao,
                       decimal preco, 
                       int? quantidade,
                       Categoria categoria)
        {
            IdProduto = idProduto;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
        }

        public Guid IdProduto { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int? Quantidade { get; private set; }
        public Categoria Categoria { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }

        #region Validações
        private void Validar()
        {

        }

        private void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Obrigatório um nome")
                .Length(3, 50).WithMessage("Obrigatório no mínimo 3 caracteres a 50 caracteres.");
        }

        private void ValidarPreco()
        {
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("Obrigatório um preço")
                .NotEqual(0).WithMessage("Obrigatório um valor acima de zero");
        }
        #endregion
    }
}
