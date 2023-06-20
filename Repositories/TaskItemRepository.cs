
using CLI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CLI.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        readonly TaskManagerContext taskManagerContext;
        public TaskItemRepository(TaskManagerContext context)
        {
            taskManagerContext = context;
        }
        public long? Add(TaskItem entity)
        {
            var taskList = this.taskManagerContext.TaskLists.Where(x=>x.taskListId==entity.TaskListId).FirstOrDefault();
            entity.TaskList = taskList==null? new TaskList(): taskList;
            EntityEntry<TaskItem> addedEnTaskItem = this.taskManagerContext.TaskItems.Add(entity);
           
           this.taskManagerContext.SaveChanges();
           return addedEnTaskItem.Entity.taskItemId;
        }

        public bool Delete(long entityId)
        {
           var entity= taskManagerContext.TaskItems.Where(x=>x.taskItemId==entityId).FirstOrDefault();
            if(entity!=null)
            {
                taskManagerContext.TaskItems.Remove(entity);
                taskManagerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public TaskItem? Get(long id)
        {
            return this.taskManagerContext.TaskItems.Where(x=> x.taskItemId == id).FirstOrDefault();
        }

        public IEnumerable<TaskItem> GetAll()
        {
             return taskManagerContext.TaskItems.AsEnumerable<TaskItem>();
        }

        public IEnumerable<TaskItem> GetAllTaskItems(long listId)
        {
            return taskManagerContext.TaskItems.Where(x=>x.TaskListId == listId).AsEnumerable<TaskItem>();
        }


        public long Update(TaskItem entity)
        {
            TaskItem? updateItem =  taskManagerContext.TaskItems.Where(x=>x.taskItemId == entity.taskItemId).FirstOrDefault();
            if(updateItem!=null)
            {
                updateItem.taskItemName = entity.taskItemName;
            
                //EntityEntry<TaskList>? item = taskManagerContext.Update(updateItem);
                this.taskManagerContext.SaveChanges();
                    
                return updateItem.TaskListId;
            }
            return 0;
        }
    }

}