using WineStore.Core.Messages;

namespace WineStore.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event
    {
        public Guid ProdutoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid produtoId)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
        }
    }
}
