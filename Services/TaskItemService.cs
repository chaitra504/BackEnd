using CLI.Models;
using CLI.Repositories;

namespace CLI.Service
{
    public class TaskItemService : ITaskItemService
    {
        ITaskItemRepository taskItemRepo;

        public TaskItemService( ITaskItemRepository taskItemRepository)
        {
           taskItemRepo = taskItemRepository;
        }

        public long? AddTaskItem(TaskItem item)
        {
            return taskItemRepo.Add(item);
        }

        public bool DeleteTaskItem(long itemId)
        {
           return taskItemRepo.Delete(itemId);
        }

        public TaskItem? Get(long itemId)
        {
           return taskItemRepo.Get(itemId);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            var result = taskItemRepo.GetAll();
            return result;
        }

        public IEnumerable<TaskItem> GetAll(long listId)
        {
            return taskItemRepo.GetAllTaskItems(listId);
        }

        public long UpdateTaskItem(TaskItem item)
        {
            return taskItemRepo.Update(item);
        }
    }
}