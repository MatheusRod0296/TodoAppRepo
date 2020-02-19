using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateToDoCommand : Notifiable, ICommand
    {
        public UpdateToDoCommand()
        {

        }

        public UpdateToDoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "por favor, descreva melhor esta tarefa")
                .HasMinLen(User, 6, "User", "usuario invalido")
            );
        }
    }
}