using ProductosAPI.Models;

namespace ProductosAPI.Repositories.ProductoRepository
{
    public interface IProductoRepository
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
    }
}
