using System;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public class SagaRepository<T> : ISagaRepository<T> where T: Saga, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public SagaRepository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(Saga aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion, false);
        }

        public T GetById(Guid id)
        {
            var saga = new T();//lots of ways to do this
            var events = _storage.GetEventsForAggregate(id);
            saga.LoadsFromHistory(events);
            return saga;
        }
    }
}