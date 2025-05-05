using ProductosAPI.Dtos.Productos;
using ProductosAPI.Models;

namespace ProductosAPI.Services.ProductoService
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
        Task<Producto?> Crear(ProductoSaveDto producto);
    }
}
