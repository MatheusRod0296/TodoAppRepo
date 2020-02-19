using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
         void Create(Todoitem todo);
         void Update(Todoitem todo);
      
    }
}