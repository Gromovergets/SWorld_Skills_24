using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual Card? Card { get; set; }

    public virtual Patient? IdRole1 { get; set; }

    public virtual Doctor? IdRoleNavigation { get; set; }
}
