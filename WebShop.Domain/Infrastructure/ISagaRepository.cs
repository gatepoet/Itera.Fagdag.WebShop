using System;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public interface ISagaRepository<out T> where T : Saga, new()
    {
        void Save(Saga saga, int expectedVersion);
        T GetById(Guid id);
    }
}