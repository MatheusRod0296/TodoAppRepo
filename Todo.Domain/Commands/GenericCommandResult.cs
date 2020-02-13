using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResult: ICommandResult
    {
        public bool Sucess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}