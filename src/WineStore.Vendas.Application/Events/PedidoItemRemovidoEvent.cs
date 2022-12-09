using WineStore.Core.Messages;

namespace WineStore.Vendas.Application.Events
{
    public class PedidoItemRemovidoEvent : Event
    {
        public Guid ClienteId { get; private set; }

        public Guid PedidoId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public PedidoItemRemovidoEvent(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }
    }
}
