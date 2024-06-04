using System;
using System.Collections.Generic;

namespace TreasureBO;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Capital { get; set; }

    public double? Areas { get; set; }

    public double? Population { get; set; }

    public virtual ICollection<SeaArea> SeaAreas { get; set; } = new List<SeaArea>();
}
