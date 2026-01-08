using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Models;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipoProductos()
        {
            return await _context.TipoProductos.ToListAsync();
        }

        // POST: api/TipoProductos
        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Add(tipoProducto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTipoProductos", new { id = tipoProducto.Id }, tipoProducto);
        }

        // DELETE: api/TipoProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProducto(int id)
        {
            var tipo = await _context.TipoProductos.FindAsync(id);
            if (tipo == null) return NotFound();

            _context.TipoProductos.Remove(tipo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}