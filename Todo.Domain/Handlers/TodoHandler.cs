using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable
      , IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository  repository;

        public TodoHandler(ITodoRepository repository)
        {
            this.repository = repository;
        }

        public ICommandResult Handler(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}