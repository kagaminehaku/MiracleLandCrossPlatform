using System;
using System.Collections.Generic;

namespace DTOCore;

public partial class UserAccount
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Type { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
