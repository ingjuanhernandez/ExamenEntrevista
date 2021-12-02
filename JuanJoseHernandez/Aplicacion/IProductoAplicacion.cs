using JuanJoseHernandez.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuanJoseHernandez.Aplicacion
{
    public interface IProductoAplicacion
    {
        public Task<int> AgregaProducto(Producto producto);
        public Task<int> EditarProducto(Producto producto);
        public Task<int> EliminarProdcuto(int id);
        public Task<List<Producto>> SeleccionarProducto();
        public Task<Producto> SeleccionarUnoProducto(int id);
    }
}
