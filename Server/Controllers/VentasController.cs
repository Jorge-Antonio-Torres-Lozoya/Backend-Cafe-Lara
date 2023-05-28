using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Act17.Server;
using Act17.Shared.Models;

namespace Act17.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly BdCafeteriaContexto _context;

        public VentasController(BdCafeteriaContexto context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
          if (_context.Ventas == null)
          {
              return NotFound();
          }

            return await _context.Ventas
                   .Include(v => v.Cliente)
                   .Include(v => v.Productos)
                   .ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
          if (_context.Ventas == null)
          {
              return NotFound();
          }
            var venta = await _context.Ventas
                 .Include(r => r.Cliente)
                 .Include(v => v.Productos)
                 .FirstOrDefaultAsync(v => v.VentaId == id);


            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.VentaId)
            {
                return BadRequest();
            }

            var ventaExistente = await _context.Ventas
                .Include(v => v.Productos)
                .FirstOrDefaultAsync(v => v.VentaId == id);

            if (ventaExistente == null)
            {
                return NotFound();
            }

            // Actualizar los campos de la venta existente con los valores de la venta actualizada
            ventaExistente.Monto = venta.Monto;
            ventaExistente.Cantidad = venta.Cantidad;
            ventaExistente.Fecha_venta = venta.Fecha_venta;
            ventaExistente.ClienteId = venta.ClienteId;

            // Actualizar la relación con los productos
            if (venta.ProductoIds != null && venta.ProductoIds.Any())
            {
                ventaExistente.Productos.Clear();

                foreach (var productoId in venta.ProductoIds)
                {
                    var producto = await _context.Productos.FindAsync(productoId);
                    if (producto != null)
                    {
                        ventaExistente.Productos.Add(producto);
                    }
                }
            }
            else
            {
                ventaExistente.Productos.Clear();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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
        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            if (venta.ProductoIds != null && venta.ProductoIds.Any())
            {
                venta.Productos = new List<Producto>();

                foreach (var productoId in venta.ProductoIds)
                {
                    var producto = await _context.Productos.FindAsync(productoId);
                    if (producto != null)
                    {
                        producto.Stock -= venta.Cantidad;
                        venta.Productos.Add(producto);
                    }
                }
            }

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenta", new { id = venta.VentaId }, venta);
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return (_context.Ventas?.Any(e => e.VentaId == id)).GetValueOrDefault();
        }
    }
}
