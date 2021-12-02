using JuanJoseHernandez.Aplicacion;
using JuanJoseHernandez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuanJoseHernandez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoAplicacion _productoAplicacion;
        public ProductoController(IProductoAplicacion productoAplicacion)
        {
            _productoAplicacion = productoAplicacion;
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<List<Producto>>> ObtenerProductosAsync()
        {
            try
            {
                var response = await _productoAplicacion.SeleccionarProducto();


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet, Route("{id}")] 
        public async Task<ActionResult<Producto>> ObtenerProductoAsync(int id)
        {
            try
            {
                var response = await _productoAplicacion.SeleccionarUnoProducto(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost, Route("")]  // agregar nuevo producto
        public async Task<ActionResult<int>> AgregarProductoAsync(Producto producto)
        {
            try
            {
                var response = await _productoAplicacion.AgregaProducto(producto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete, Route("{id}")] //Eliminar Producto
        public async Task<ActionResult<bool>> EliminarProductoAsync(int id)
        {
            try
            {
                var response = await _productoAplicacion.EliminarProdcuto(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut, Route("")]  // Editar producto
        public async Task<ActionResult<int>> EditarProductoAsync(Producto producto)
        {
            try
            {
                var response = await _productoAplicacion.EditarProducto(producto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
