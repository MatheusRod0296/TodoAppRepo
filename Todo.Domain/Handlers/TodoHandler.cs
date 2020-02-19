using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable
      , IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository  _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(CreateTodoCommand command)
        {
            //Fail fast validation
           command.Validate();
           if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua terefa esta errada!", command.Notifications);

            //Geara o Todo
            var todo = new Todoitem(command.Title,  command.Date, command.User);

            //salva no banco
            _repository.Create(todo);

            ///Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo.Id);
                    
        }

      
    }
}