using Microsoft.EntityFrameworkCore;

namespace WebApiCoreAngularPrimeTechv2.Model
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<TblCustomerInvoice> TblCustomerInvoice { get; set; }
        public DbSet<TblCustomerInvoiceQuantity> TblCustomerInvoiceQuantity { get; set; }
    }
}
