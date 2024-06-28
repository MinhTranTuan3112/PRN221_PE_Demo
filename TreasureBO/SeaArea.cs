using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreasureBO;

public partial class SeaArea
{
    public int SeaId { get; set; }

    [MaxLength(255, ErrorMessage = "The name is too long")]
    [Required]
    public string SeaName { get; set; } = null!;

    public int Treasure { get; set; }

    public int Probability { get; set; }

    public int Fee { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }
}
