using POSSolution.Core.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSolution.Core.Models;

public class SalesReturnDetails : BaseModel
{
    public decimal SalesReturnQty { get; set; }

    [DataType(DataType.Currency), Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }

    [ForeignKey("SalesReturn")]
    public int SalesReturnId { get; set; }

    public int ReturnItemId { get; set; }

    public virtual SalesReturn SalesReturn { get; set; }
}
