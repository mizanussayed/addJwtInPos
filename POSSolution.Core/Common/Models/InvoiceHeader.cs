using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POSSolution.Core.Common.Models;

public class InvoiceHeader : BaseModel
{
    public string InvoiceNo { get; set; }

    public decimal TotalQuantity { get; set; }


    [DataType(DataType.Currency), Column(TypeName = "money")]
    public decimal SubTotal { get; set; }


    [DataType(DataType.Currency), Column(TypeName = "money")]
    public decimal OtherCharges { get; set; }



    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.Currency), Column(TypeName = "money")]
    public decimal GrandTotal { get; set; }

    public string Note { get; set; }
}
