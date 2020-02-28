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
      , IHandler<UpdateToDoCommand>
      , IHandler<MarkTodoAsDoneCommand>
      , IHandler<MarkToDoAsUndoneCommand>
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
            var todo = new TodoItem(command.Title,  command.Date, command.User);

            //salva no banco
            _repository.Create(todo);

            ///Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo.Id);
                    
        }

        public ICommandResult Handler(UpdateToDoCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "ops, parece que sua tarefa esta errada", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(true, "Salvo com sucesso", todo.Id);
        }

        public ICommandResult Handler(MarkTodoAsDoneCommand command)
        {
           command.Validate();
           if(command.Invalid)
            return new GenericCommandResult(false, "ops, tem algo errado ai", command.Notifications);

            //reidtratar o obj, necessario por conta do EF
            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "DONE!", command.Id);
        }

        public ICommandResult Handler(MarkToDoAsUndoneCommand command)
        {
            command.Validate();
           if(command.Invalid)
            return new GenericCommandResult(false, "ops, tem algo errado ai", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUnDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "DONE!", command.Id);
        }
    }
}