﻿using System.ComponentModel.DataAnnotations;
using ProductosAPI.Dtos.Productos;
using ProductosAPI.Exceptions;
using ProductosAPI.Models;
using ProductosAPI.Repositories.ProductoRepository;

namespace ProductosAPI.Services.ProductoService
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Producto?> Crear(ProductoSaveDto producto)
        {
            Validator.ValidateObject(producto, new ValidationContext(producto), true);
            Producto save = new Producto()
            {
                Estado = producto.Estado,
                Nombre = producto.Nombre
            };

            return await _repository.Crear(save);
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            Producto? existente = await _repository.ObtenerPorId(id);

            if (existente == null)
            {
                throw new NoEncontradoException("Producto no existe.");
            }

            return existente;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }
    }
}
