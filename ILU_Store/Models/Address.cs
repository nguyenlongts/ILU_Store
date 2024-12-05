using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ILU_Store.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressName { get; set; } = null!;

    public bool DefaultAddress { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; }

}
