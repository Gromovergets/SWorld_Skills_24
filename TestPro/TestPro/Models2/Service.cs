using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Cost { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
