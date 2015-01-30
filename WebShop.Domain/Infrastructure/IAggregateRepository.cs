using System;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public interface IAggregateRepository<out T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}