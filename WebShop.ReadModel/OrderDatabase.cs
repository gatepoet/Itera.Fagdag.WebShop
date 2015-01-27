using System;
using System.Collections.Generic;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public static class OrderDatabase
    {
        public static Dictionary<Guid, OrderDto> Orders = new Dictionary<Guid, OrderDto>();
    }
}