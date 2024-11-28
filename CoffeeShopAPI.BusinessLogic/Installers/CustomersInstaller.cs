using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Services;
using CoffeeShopAPI.BusinessLogic.Decorators;
using Scrutor;
using CoffeeShopAPI.BusinessLogic.Commands;

namespace CoffeeShopAPI.BusinessLogic.Installers
{
    public static class CustomersInstaller
    {
        public static IServiceCollection AddCustomers(this IServiceCollection services)
        {
            services
                .AddScoped<ICustomersService, CustomersService>()
                .Decorate<ICustomersService, LoggingCustomerServiceDecorator>()
                .AddScoped<IRegularCustomerFactory, RegularCustomerFactory>()
                .AddScoped<IPremiumCustomerFactory, PremiumCustomerFactory>()
                .AddScoped<ICommandHandler, CommandHandler>();

            return services;
        }
    }
}