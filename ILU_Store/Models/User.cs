using System;
using System.Collections.Generic;

namespace ILU_Store.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int RoleId { get; set; } = 3;
    public int Status { get; set; }
    public DateTime DoB { get; set; }
    public int Gender { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual Role Role { get; set; }
}
