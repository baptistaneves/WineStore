using MediatR;
using WineStore.Catalogo.Application.Services;
using WineStore.Catalogo.Data;
using WineStore.Catalogo.Data.Repository;
using WineStore.Catalogo.Domain;
using WineStore.Catalogo.Domain.Events;
using WineStore.Core.Mediator;
using WineStore.Core.Messages.CommonMessages.IntegrationEvents;
using WineStore.Core.Messages.CommonMessages.Notifications;
using WineStore.Pagamentos.AntiCorruption;
using WineStore.Pagamentos.Business;
using WineStore.Pagamentos.Business.Events;
using WineStore.Pagamentos.Data;
using WineStore.Pagamentos.Data.Repository;
using WineStore.Vendas.Application.Commands;
using WineStore.Vendas.Application.Events;
using WineStore.Vendas.Application.Queries;
using WineStore.Vendas.Data;
using WineStore.Vendas.Data.Repository;
using WineStore.Vendas.Domain;

namespace WineStore.WebApp.MVC.Extensions
{
    public static class DependecyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Domain (Mediator)
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            //Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, ProdutoEventHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Vendas
            services.AddScoped<VendasContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoPagamentoRealizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoPagamentoRecusadoEvent>, PedidoEventHandler>();

            //Pagamentos
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager,WineStore.Pagamentos.AntiCorruption.ConfigurationManager>();
            services.AddScoped<PagamentoContext>();

            services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>, PagamentoEventHandler>();
        }
    }
}
