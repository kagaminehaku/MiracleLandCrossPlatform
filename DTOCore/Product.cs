using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class Product
{
    public int Pid { get; set; }

    public string Pname { get; set; }

    public int Pprice { get; set; }

    public int Pquantity { get; set; }

    public string Pinfo { get; set; }

    public string Pimg { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
