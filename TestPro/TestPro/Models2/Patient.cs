using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Oname { get; set; }

    public string? NumberPassport { get; set; }

    public string? SeriaPassport { get; set; }

    public string? Gender { get; set; }

    public string? Adress { get; set; }

    public string? Number { get; set; }

    public string? Email { get; set; }

    public int? IdCard { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
