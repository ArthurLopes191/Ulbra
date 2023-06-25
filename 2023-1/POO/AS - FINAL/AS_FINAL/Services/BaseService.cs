using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;
using FluentValidation;

namespace AS_FINAL.Services
{
    public class BaseService
    {
        // private readonly INotificador _notificador;

        protected BaseService()
        {
        }

        // protected void Notificar(ValidationResult validationResult)
        // {
        //     foreach (var error in validationResult.Errors)
        //     {
        //         Notificar(error.ErrorMessage);
        //     }
        // }

        // protected void Notificar(string mensagem)
        // {
        //     _notificador.Handle(new Notificacao(mensagem));
        // }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if(validator.IsValid) return true;

            return false;
        }
    }
}