﻿using System;
using System.Collections.Generic;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion, bool publish = true);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}