
using CLI.Models;

namespace CLI.Repositories
{
public interface ITaskItemRepository : IDataRepository<TaskItem>
    {
       public IEnumerable<TaskItem> GetAllTaskItems(long listId);
    }
}