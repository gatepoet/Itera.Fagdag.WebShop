using System;
using System.Collections.Generic;

namespace Itera.Fagdag.WebShop.Domain
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}