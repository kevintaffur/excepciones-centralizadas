using Microsoft.EntityFrameworkCore;
using ProductosAPI.Models;

namespace ProductosAPI.Repositories.ProductoRepository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly Productos2Context _context;

        public ProductoRepository(Productos2Context context)
        {
            _context = context;
        }

        public async Task<Producto?> Crear(Producto p)
        {
            await _context.Productos.AddAsync(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(e => e.Id == id && !e.Estado.Equals("N"));
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos.Where(e => !e.Estado.Equals("N")).ToListAsync();
        }
    }
}
