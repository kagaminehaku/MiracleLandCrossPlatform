using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class ShoppingCart
{
    public int Cartitemid { get; set; }

    public int Id { get; set; }

    public int Pid { get; set; }

    public int Pquantity { get; set; }

    public virtual UserAccount IdNavigation { get; set; } = null!;

    public virtual Product PidNavigation { get; set; } = null!;
}
