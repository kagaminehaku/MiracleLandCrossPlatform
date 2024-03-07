using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public int Pid { get; set; }

    public int Pquantity { get; set; }

    public virtual UserAccount IdNavigation { get; set; }

    public virtual Product PidNavigation { get; set; }
}
