namespace CoffeeShopAPI.BusinessLogic.Commands
{
    public class CommandHandler : ICommandHandler
    {
        public async Task HandleAsync(ICommand command)
        {
            await command.ExecuteAsync();
        }
    }
}
