﻿using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class EventType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
