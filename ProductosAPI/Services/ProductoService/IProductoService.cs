using ProductosAPI.Models;

namespace ProductosAPI.Services.ProductoService
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
    }
}
