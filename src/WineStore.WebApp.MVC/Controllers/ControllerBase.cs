using MediatR;
using Microsoft.AspNetCore.Mvc;
using WineStore.Core.Mediator;
using WineStore.Core.Messages.CommonMessages.Notifications;

namespace WineStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _notifications;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler) notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacoes();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
    }
}
