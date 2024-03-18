using System;
using System.Collections.Generic;

namespace TestPro.Models2;

public partial class Card
{
    public int Id { get; set; }

    public int IdPatient { get; set; }

    public string IdDoctor { get; set; } = null!;

    public DateTime? DateP { get; set; }

    public string? InfoDop { get; set; }

    public string? Directions { get; set; }

    public int IdDiseases { get; set; }

    public int? Recipe { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Disease IdDiseasesNavigation { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;

    public virtual Drug? RecipeNavigation { get; set; }
}
