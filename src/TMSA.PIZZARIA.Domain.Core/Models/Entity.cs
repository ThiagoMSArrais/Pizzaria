using FluentValidation;
using FluentValidation.Results;
using System;

namespace TMSA.PIZZARIA.Domain.Core.Models
{
    public abstract class Entity<TEntity> : AbstractValidator<TEntity> where TEntity : Entity<TEntity>
    {

        public Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }

        public abstract bool EhValido();
        public ValidationResult ValidationResult { get; protected set; }
    }
}
