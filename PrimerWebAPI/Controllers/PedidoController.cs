using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerWebAPI.Modelos;

namespace PrimerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // ✅ GET: api/pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }

        // ✅ POST: api/pedido
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido([FromBody] Pedido pedido)
        {
            pedido.FechaPedido = DateTime.Now;

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        // ✅ PUT: api/pedido/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            var pedidoExistente = await _context.Pedidos.FindAsync(id);

            if (pedidoExistente == null)
                return NotFound();

            // Actualizar solo los campos necesarios
            pedidoExistente.ClienteNombre = pedido.ClienteNombre;
            pedidoExistente.Producto = pedido.Producto;
            pedidoExistente.Cantidad = pedido.Cantidad;
            pedidoExistente.Precio = pedido.Precio;
            pedidoExistente.Estado = pedido.Estado;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
                return NotFound();

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}