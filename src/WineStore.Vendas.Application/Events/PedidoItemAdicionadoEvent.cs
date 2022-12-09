using WineStore.Core.Messages;

namespace WineStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public Guid ProdutoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItemAdicionadoEvent(Guid clienteId, Guid produtoId, Guid pedidoId, decimal valorUnitario, int quantidade, string produtoNome)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            ProdutoNome = produtoNome;
        }
    }
}
