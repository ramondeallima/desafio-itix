using System;
using System.Collections.Generic;
using System.Text;
using Unimed.Agendamentos.BLL.Notifications;

namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
