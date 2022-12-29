using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreAngularPrimeTechv2.Model
{
    public class TblCustomerInvoiceQuantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
