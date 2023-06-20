using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CLI.Models;

public partial class TaskList
{
   // [JsonIgnore]
    public long taskListId { get; set; }

    public string taskListName { get; set; } = null!;

    //[JsonIgnore]
    public DateTime createdDt { get; set; }
    
    //[JsonIgnore]
    public DateTime modifiedDt { get; set; }

    //[JsonIgnore]
    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
