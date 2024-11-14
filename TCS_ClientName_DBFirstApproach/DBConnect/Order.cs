using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCS_ClientName_DBFirstApproach.DBConnect;

public partial class Order
{
    [Key]
    public int Orderid { get; set; }

    public string? Ordername { get; set; }

    public string? Orderlocation { get; set; }
}
