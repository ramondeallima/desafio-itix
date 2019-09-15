using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.BLL.Notifications;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }



        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid) return true;

            Notificar(validador);
            return false;
            
        }
    }
}
