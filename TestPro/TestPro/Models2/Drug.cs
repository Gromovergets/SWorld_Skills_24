using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Drug
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
