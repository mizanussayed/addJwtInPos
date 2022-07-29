using POSSolution.Core.Common.Models;
using System;

namespace POSSolution.Core.Models;

public class SpecialDiscount : BaseModel
{
    public string DiscountName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    // public bool IsActive { get; set; } = false;
}
