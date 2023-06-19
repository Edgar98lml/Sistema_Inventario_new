using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {

        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDB = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (productoDB != null)
            {
                if (producto.ImageURL != null)
                {

                    productoDB.ImageURL = producto.ImageURL;

                }
                productoDB.NumeroSerie= producto.NumeroSerie;
                productoDB.Descripcion= producto.Descripcion;
                productoDB.Precio= producto.Precio;
                productoDB.Costo= producto.Costo;
                productoDB.CategoriaId= producto.CategoriaId;
                productoDB.MarcaId= producto.MarcaId;
                productoDB.PadreId= producto.PadreId;
                productoDB.Estado= producto.Estado;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string objeto)
        {
            if (objeto == "Categoria")
            {
                return _db.Categorias.Where(C => C.Estado == true).Select(C => new SelectListItem
                {
                    Text = C.Nombre,
                    Value = C.Id.ToString()
                });
            }
            if (objeto == "Marca")
            {
                return _db.Marcas.Where(C => C.Estado == true).Select(C => new SelectListItem
                {
                    Text = C.Descripcion,
                    Value = C.Id.ToString()
                });
            }
            if (objeto == "Producto")
            {
                return _db.Productos.Where(C => C.Estado == true).Select(C => new SelectListItem
                {
                    Text = C.Descripcion,
                    Value = C.Id.ToString()
                });
            }
            return null;
        }

        
    }
}
