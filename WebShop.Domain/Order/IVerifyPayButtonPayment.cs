namespace Itera.Fagdag.WebShop.Domain.Order
{
    public interface IVerifyPayButtonPayment
    {
        void VerifyToken(string token);
    }
}