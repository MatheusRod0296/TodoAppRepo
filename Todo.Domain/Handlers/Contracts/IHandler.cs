using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handler(ICommand command);
    }
}