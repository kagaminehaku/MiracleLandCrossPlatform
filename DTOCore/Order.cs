using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class Order
{
    public int Orderid { get; set; }

    public int Userid { get; set; }

    public long Total { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual UserAccount User { get; set; }
}
