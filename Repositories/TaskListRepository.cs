
using CLI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CLI.Repositories
{
    public class TaskListRepository : IDataRepository<TaskList>
    {
        readonly TaskManagerContext taskManagerContext;
        public TaskListRepository(TaskManagerContext context)
        {
            taskManagerContext = context;
        }

        public long? Add(TaskList entity)
        {
           EntityEntry<TaskList> addedEnTaskList = this.taskManagerContext.TaskLists.Add(entity);
           
           this.taskManagerContext.SaveChanges();
           return addedEnTaskList.Entity.taskListId;
        }

        public long Add(TaskItem entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long entityId)
        {
            var entity= taskManagerContext.TaskLists.Where(x=>x.taskListId==entityId).FirstOrDefault();
            if(entity!=null)
            {
                entity.TaskItems  =(TaskItem[]) taskManagerContext.TaskItems.Where(x=>x.TaskListId==entityId).AsEnumerable<TaskItem>().ToArray();
                taskManagerContext.TaskItems.RemoveRange(entity.TaskItems.ToList());
                taskManagerContext.TaskLists.Remove(entity);
                taskManagerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public TaskList? Get(long id)
        {
            return this.taskManagerContext.TaskLists.Where(x=> x.taskListId == id).FirstOrDefault();
        }

        public IEnumerable<TaskList> GetAll()
        {
            return taskManagerContext.TaskLists.AsEnumerable<TaskList>();
        }

 
        public long Update(TaskList entity)
        {
            TaskList? updateItem =  taskManagerContext.TaskLists.Where(x=>x.taskListId == entity.taskListId).FirstOrDefault();
            if(updateItem!=null)
            {
                updateItem.taskListName = entity.taskListName;
            
                //EntityEntry<TaskList>? item = taskManagerContext.Update(updateItem);
                this.taskManagerContext.SaveChanges();
                    
                return updateItem.taskListId;
            }
            return 0;
        }

        public long Update(TaskItem entity)
        {
            throw new NotImplementedException();
        }

    }
}