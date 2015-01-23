﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Itera.Fagdag.WebShop.Domain;

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
            var rep = new Repository<ShoppingCart>(storage);
            var commands = new ShoppingCartCommandHandlers(rep);
            bus.RegisterHandler<CreateCart>(commands.Handle);
            bus.RegisterHandler<AddCartItem>(commands.Handle);
            bus.RegisterHandler<RemoveCartItem>(commands.Handle);
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