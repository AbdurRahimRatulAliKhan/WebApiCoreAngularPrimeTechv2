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
    public class CustomerInvoiceQuantitiesController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerInvoiceQuantitiesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInvoiceQuantities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomerInvoiceQuantity>>> GetTblCustomerInvoiceQuantity()
        {
            return await _context.TblCustomerInvoiceQuantity.ToListAsync();
        }

        // GET: api/CustomerInvoiceQuantities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerInvoiceQuantity>> GetTblCustomerInvoiceQuantity(int id)
        {
            var tblCustomerInvoiceQuantity = await _context.TblCustomerInvoiceQuantity.FindAsync(id);

            if (tblCustomerInvoiceQuantity == null)
            {
                return NotFound();
            }

            return tblCustomerInvoiceQuantity;
        }

        // PUT: api/CustomerInvoiceQuantities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomerInvoiceQuantity(int id, TblCustomerInvoiceQuantity tblCustomerInvoiceQuantity)
        {
            if (id != tblCustomerInvoiceQuantity.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomerInvoiceQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerInvoiceQuantityExists(id))
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

        // POST: api/CustomerInvoiceQuantities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomerInvoiceQuantity>> PostTblCustomerInvoiceQuantity(TblCustomerInvoiceQuantity tblCustomerInvoiceQuantity)
        {
            _context.TblCustomerInvoiceQuantity.Add(tblCustomerInvoiceQuantity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomerInvoiceQuantity", new { id = tblCustomerInvoiceQuantity.Id }, tblCustomerInvoiceQuantity);
        }

        // DELETE: api/CustomerInvoiceQuantities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomerInvoiceQuantity(int id)
        {
            var tblCustomerInvoiceQuantity = await _context.TblCustomerInvoiceQuantity.FindAsync(id);
            if (tblCustomerInvoiceQuantity == null)
            {
                return NotFound();
            }

            _context.TblCustomerInvoiceQuantity.Remove(tblCustomerInvoiceQuantity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerInvoiceQuantityExists(int id)
        {
            return _context.TblCustomerInvoiceQuantity.Any(e => e.Id == id);
        }
    }
}
