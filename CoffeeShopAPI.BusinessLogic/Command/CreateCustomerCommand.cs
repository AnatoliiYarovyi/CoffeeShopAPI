using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        private readonly ICustomersService _customersService;
        private readonly string _type;
        private readonly string _name;
        private readonly string _email;

        public CreateCustomerCommand(ICustomersService customersService, string type, string name, string email)
        {
            _customersService = customersService;
            _type = type;
            _name = name;
            _email = email;
        }

        public async Task ExecuteAsync()
        {
            await _customersService.CreateCustomer(_type, _name, _email);
        }
    }
}

