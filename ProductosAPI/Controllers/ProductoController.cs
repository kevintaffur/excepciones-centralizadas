using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Dtos.Productos;
using ProductosAPI.Models;
using ProductosAPI.Services.ProductoService;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/productos")]
    public class ProductoController : BaseController
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<Producto> productos = await _service.ObtenerTodos();
            return Success(productos, "Productos obtenidos satisfactoriamente.");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            return Success(
                await _service.ObtenerPorId(id),
                "Producto obtenido de forma satisfactoria.");
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductoSaveDto save)
        {
            return Success(
                await _service.Crear(save),
                "Producto creado de forma satisfactoria.",
                201);
        }
    }
}
