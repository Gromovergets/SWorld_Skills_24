using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Midlename { get; set; }

    public string Proffecional { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
