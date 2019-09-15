using Microsoft.AspNetCore.Mvc;
using Unimed.Agendamentos.BLL.Interfaces;

namespace Unimed.Agendamentos.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
