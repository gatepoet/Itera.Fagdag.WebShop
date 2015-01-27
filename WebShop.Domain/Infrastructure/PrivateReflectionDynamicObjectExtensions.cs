namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public static class PrivateReflectionDynamicObjectExtensions
    {
        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }
    }
}