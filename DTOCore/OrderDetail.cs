using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class OrderDetail
{
    public int Odid { get; set; }

    public int Orderid { get; set; }

    public int Pid { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product PidNavigation { get; set; } = null!;
}
