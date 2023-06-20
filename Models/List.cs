using System;
using System.Collections.Generic;

namespace CLI.Models;

public partial class List
{
    public long ListId { get; set; }

    public string ListName { get; set; } = null!;

    public byte[]? CreatedDate { get; set; }

    public byte[]? ModifiedDate { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
