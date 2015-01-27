namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public interface Handles<T>
    {
        void Handle(T message);
    }
}