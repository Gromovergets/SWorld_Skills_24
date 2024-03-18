using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Disease
{
    public int Id { get; set; }

    public int IdCard { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
