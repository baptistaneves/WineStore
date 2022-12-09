using WineStore.Core.Messages;

namespace WineStore.Core.DomainObjects
{
    public class DomainEvents : Event
    {
        public DomainEvents(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
