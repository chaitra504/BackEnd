

using CLI.Models;
using CLI.Repositories;

namespace CLI.Service
{
public class TaskListService : ITaskListService
{

    IDataRepository<TaskList> taskListRepo;
    public TaskListService( IDataRepository<TaskList> taskListRepository)
    {
        taskListRepo = taskListRepository;
    }

 
    public IEnumerable<TaskList> GetAll()
    {
       var result = taskListRepo.GetAll();
       return result;
    }

    public long? AddTaskList(TaskList item)
    {
        return taskListRepo.Add(item);
    }

    public long UpdateTaskList(TaskList item)
    {
        return taskListRepo.Update(item);
    }

    public TaskList? Get(long listId)
    {
       return taskListRepo.Get(listId);
    }

    public bool DeleteTaskList(long listId)
    {
        return taskListRepo.Delete(listId);
    }
    }
}