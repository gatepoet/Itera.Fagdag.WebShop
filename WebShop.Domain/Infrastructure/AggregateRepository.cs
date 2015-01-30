using System;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public class AggregateRepository<T> : IAggregateRepository<T> where T : AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public AggregateRepository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            var aggregate = new T();//lots of ways to do this
            var events = _storage.GetEventsForAggregate(id);
            aggregate.LoadsFromHistory(events);
            return aggregate;
        }
    }
}