using JuanJoseHernandez.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanJoseHernandez.Aplicacion
{
    public class ProductoAplicacion : IProductoAplicacion
    {
        private IListaProductos _ltproductos;
        public ProductoAplicacion(IListaProductos ltproductos)
        {
            _ltproductos = ltproductos;
        }
        public async Task<int> AgregaProducto(Producto producto)
        {
            var consec = _ltproductos.productos.Count() > 0 ? _ltproductos.productos.Max(prod => prod.id) : 0;

            _ltproductos.productos.Add(new Producto
            {
                id = consec + 1,
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                precio = producto.precio,
                categoria = producto.categoria,
                cantidad = producto.cantidad
            });
            return 1;
        }

        public async Task<int> EditarProducto(Producto producto)
        {
            var nuevaLista = await Task.Run(() => _ltproductos.productos.Where(prod => prod.id != producto.id));
            _ltproductos.productos = nuevaLista.ToList();
            _ltproductos.productos.Add(producto);
            return 1;
            
        }

        public async Task<int> EliminarProdcuto(int id)
        {
            var listaDos = await Task.Run(() => _ltproductos.productos.Where(prod => prod.id != id));
            _ltproductos.productos = listaDos.ToList();
            return 1;

        }

        public async Task<List<Producto>> SeleccionarProducto()
        {
            return await Task.Run(() => _ltproductos.productos);
        }

        public async Task<Producto> SeleccionarUnoProducto(int id)
        {
            return await Task.Run(() => _ltproductos.productos.FirstOrDefault(prod => prod.id == id));
        }
    }
}
