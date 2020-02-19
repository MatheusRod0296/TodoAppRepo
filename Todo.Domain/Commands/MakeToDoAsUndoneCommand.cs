using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MakeToDoAsUndoneCommand: Notifiable, ICommand
    {
          public Guid Id { get; set; }

        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasLen(Id.ToString(), 16, "id", "id invalido")
                .HasMinLen(User, 6, "user", "Usuario invalido")
                
                
            );
        }
    }
}