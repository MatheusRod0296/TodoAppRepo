using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(Todoitem todo)
        {
           
        }

        public Todoitem GetById(Guid id, string user)
        {
            return new Todoitem("", DateTime.Now, "");
        }

        public void Update(Todoitem todo)
        {
            
        }
    }
}