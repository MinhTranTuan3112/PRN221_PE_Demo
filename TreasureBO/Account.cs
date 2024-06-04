using System;
using System.Collections.Generic;

namespace TreasureBO;

public partial class Account
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public string Status { get; set; } = null!;
}
