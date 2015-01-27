using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Itera.Fagdag.WebShop.Domain;
using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.Order;
using Itera.Fagdag.WebShop.Domain.ShoppingCart;
using Itera.Fagdag.WebShop.Domain.User;
using Itera.Fagdag.WebShop.Domain.UserFavorites;
using Itera.Fagdag.WebShop.ReadModel;

namespace Itera.Fagdag.WebShop.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bus = new FakeBus();

            var storage = new EventStore(bus);

            var order = new OrderCommandHandlers(
                new Repository<Order>(storage));
            bus.RegisterHandler<CreateOrder>(order.Handle);
            bus.RegisterHandler<SelectBringPickupPoint>(order.Handle);
            bus.RegisterHandler<ConfirmPayButtonPayment>(order.Handle);

            var shoppingCart = new ShoppingCartCommandHandlers(
                new Repository<ShoppingCart>(storage));
            bus.RegisterHandler<CreateCart>(shoppingCart.Handle);
            bus.RegisterHandler<AddCartItem>(shoppingCart.Handle);
            bus.RegisterHandler<RemoveCartItem>(shoppingCart.Handle);
            bus.RegisterHandler<CheckOutCart>(shoppingCart.Handle);

            var notifications = new ProductAvailabilityCommandHandlers(
                new Repository<ProductAvailabilityNotification>(storage));
            bus.RegisterHandler<RemoveProductAvailabilityNotification>(notifications.Handle);
            bus.RegisterHandler<AddProductAvailabilityNotification>(notifications.Handle);
            bus.RegisterHandler<ProductCreated>(notifications.Handle);

            var favorites = new UserFavoriteCommandHandlers(
                new Repository<UserFavorites>(storage));
            bus.RegisterHandler<UserCreated>(favorites.Handle);
            bus.RegisterHandler<AddToFavorites>(favorites.Handle);
            bus.RegisterHandler<RemoveFromFavorites>(favorites.Handle);


            var detail = new ShoppingCartView();
            bus.RegisterHandler<CartCreated>(detail.Handle);
            bus.RegisterHandler<CartItemAdded>(detail.Handle);
            bus.RegisterHandler<CartItemRemoved>(detail.Handle);

            ServiceLocator.Bus = bus;
            ProductDatabase.LoadFromDisk(Server.MapPath("~/produkter"));
        }
    }

    public class ServiceLocator
    {
        public static FakeBus Bus { get; set; }
    }
}
