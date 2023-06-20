using CLI.Models;

namespace CLI.Service
{
    public interface ITaskItemService{
         IEnumerable<TaskItem> GetAll(long listId);

         long? AddTaskItem(TaskItem item);
         
         long UpdateTaskItem(TaskItem item);

         TaskItem? Get(long itemId);

         bool DeleteTaskItem(long itemId);
    }
}