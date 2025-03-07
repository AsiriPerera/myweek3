using System;
using System.Collections.Generic;

namespace EntityModels.Models;

public partial class Store
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
