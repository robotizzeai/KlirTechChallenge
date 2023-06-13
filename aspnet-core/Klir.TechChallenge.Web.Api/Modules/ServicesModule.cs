using Autofac;
using KlirTechChallenge.Web.Api;
using System;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Module = Autofac.Module;
using Klir.TechChallenge.Web.Api.Repository;
using Klir.TechChallenge.Web.Api.Services;

namespace Klir.TechChallenge.Web.Api.Modules
{
    public class ServicesModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<CartService>().As<ICartService>().SingleInstance();
            builder.RegisterType<MockProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<CartRepository>().As<ICartRepository>().SingleInstance();
            builder.RegisterType<CheckoutService>().As<ICheckoutService>().SingleInstance();
        }
    }
}
