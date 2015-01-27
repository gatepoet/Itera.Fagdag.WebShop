namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class VerifyPayButtonPayment : IVerifyPayButtonPayment
    {
        public void VerifyToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new PaymillTokenVerificationException(token);
        }
    }
}