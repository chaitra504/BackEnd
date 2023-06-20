using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CLI.Models;

public partial class TaskItem
{
    public long? taskItemId { get; set; }

    public string taskItemName { get; set; } = null!;

    public bool isTaskComplete { get; set; }

    public DateTime createdDt { get; set; }

    public DateTime modifiedDt { get; set; }
    
    public long TaskListId { get; set; }
    [JsonIgnore]
    public virtual TaskList? TaskList { get; set; } = null!;
}
