using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Event
{
    public int Id { get; set; }

    public int IdCard { get; set; }

    public int IdService { get; set; }

    public string Name { get; set; } = null!;

    public string? Result { get; set; }

    public DateTime? Date { get; set; }

    public int? Type { get; set; }

    public virtual Card IdCardNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;

    public virtual EventType? TypeNavigation { get; set; }
}
