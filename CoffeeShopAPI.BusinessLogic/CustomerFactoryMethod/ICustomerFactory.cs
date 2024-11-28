using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod

{
    public interface ICustomerFactory
    {
        CustomerDto CreateCustomer(string name, string email);
    }

    public interface IRegularCustomerFactory : ICustomerFactory { }
    public interface IPremiumCustomerFactory : ICustomerFactory { }
}
