using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreAngularPrimeTechv2.Model
{
    public class TblCustomerInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string FirstName { get; set; }
        [StringLength(150)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime Doj { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }
        public string Description { get; set; }
        public int QuantityID { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
