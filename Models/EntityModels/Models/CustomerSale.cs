using System;
using System.Collections.Generic;

namespace EntityModels.Models;

public partial class CustomerSale
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime? DateSold { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }
}
