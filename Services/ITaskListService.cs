using CLI.Models;

namespace CLI.Service
{
    public interface ITaskListService{
         IEnumerable<TaskList> GetAll();

         long? AddTaskList(TaskList item);
         
         long UpdateTaskList(TaskList item);

         TaskList? Get(long listId);

         bool DeleteTaskList(long listId);
    }
}