using POSSolution.Core.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSolution.Core.Models;

public class StockCount : BaseModel
{
    public int ItemId { get; set; }
    public decimal PurchaseQty { get; set; }
    public decimal SalesQty { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Balance { get; set; }       
}
