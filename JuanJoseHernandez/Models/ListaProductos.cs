using System.Collections.Generic;

namespace JuanJoseHernandez.Models
{
    public class ListaProductos : IListaProductos
    {
        private List<Producto> Productos;
        public List<Producto> productos
        {
            get
            {
                if (Productos == null)
                {
                    Productos = new List<Producto>();
                }
                return Productos;
            }
            set
            {
                Productos = value;
            }
        }

    }

    public interface IListaProductos
    {
        public List<Producto> productos { get; set; }

    }
}
