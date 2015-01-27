namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;

    }
}