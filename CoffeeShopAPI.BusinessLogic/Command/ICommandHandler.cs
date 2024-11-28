namespace CoffeeShopAPI.BusinessLogic.Commands
{
    public interface ICommandHandler
    {
        Task HandleAsync(ICommand command);
    }
}

