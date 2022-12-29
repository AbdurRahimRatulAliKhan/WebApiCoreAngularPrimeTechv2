using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreAngularPrimeTechv2.Model;

namespace WebApiCoreAngularPrimeTechv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInvoicesController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerInvoicesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomerInvoice>>> GetTblCustomerInvoice()
        {
            return await _context.TblCustomerInvoice.ToListAsync();
        }

        // GET: api/CustomerInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerInvoice>> GetTblCustomerInvoice(int id)
        {
            var tblCustomerInvoice = await _context.TblCustomerInvoice.FindAsync(id);

            if (tblCustomerInvoice == null)
            {
                return NotFound();
            }

            return tblCustomerInvoice;
        }

        // PUT: api/CustomerInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomerInvoice(int id, TblCustomerInvoice tblCustomerInvoice)
        {
            if (id != tblCustomerInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomerInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerInvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomerInvoice>> PostTblCustomerInvoice(TblCustomerInvoice tblCustomerInvoice)
        {
            _context.TblCustomerInvoice.Add(tblCustomerInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomerInvoice", new { id = tblCustomerInvoice.Id }, tblCustomerInvoice);
        }

        // DELETE: api/CustomerInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomerInvoice(int id)
        {
            var tblCustomerInvoice = await _context.TblCustomerInvoice.FindAsync(id);
            if (tblCustomerInvoice == null)
            {
                return NotFound();
            }

            _context.TblCustomerInvoice.Remove(tblCustomerInvoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerInvoiceExists(int id)
        {
            return _context.TblCustomerInvoice.Any(e => e.Id == id);
        }
    }
}
