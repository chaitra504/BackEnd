using System;
using System.Collections.Generic;

namespace CLI.Models;

public partial class Task
{
    public long TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public byte[]? IsTaskComplete { get; set; }

    public byte[]? CreatedDate { get; set; }

    public byte[]? ModifiedDate { get; set; }

    public long ListId { get; set; }

    public virtual List List { get; set; } = null!;
}
