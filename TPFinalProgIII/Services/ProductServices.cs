using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Product;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ProductServices : BaseServices, IProductServices
    {
        public ProductServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Producto> GetAll()
        {
            return _context.Producto.Include(c => c.IdTipoProductoNavigation).ToList();
        }

        public IEnumerable<Producto> GetAllId()
        {
            return _context.Producto;
        }

        public Producto GetOne (int productId)
        {
            return _context.Producto.Include(c => c.IdTipoProductoNavigation).SingleOrDefault(x => x.IdProducto == productId);
        }

        public IEnumerable<Producto> GetByName (string productName)
        {
            return _context.Producto.Where(x => EF.Functions.Like(x.IdTipoProductoNavigation.Descripcion, $"%{productName}")).Include(c => c.IdTipoProductoNavigation);
        }

        public void DeleteProduct(Producto product)
        {
            _context.Producto.Remove(product);
            _context.SaveChanges();
        }

        public Producto UpdateProduct(ProductCreateOrUpdate data)
        {
            var product = GetOne(data.idProducto);
            if (product != null)
            {
                product.IdTipoProducto = data.idTipoProducto;
                product.StockActual = data.StockActual;
                product.Precio = data.Precio;

                _context.SaveChanges();
            }
            return product;
        }

        public Producto CreateProduct(ProductCreateOrUpdate data)
        {
            var product = new Producto()
            {
                IdProducto = data.idProducto,
                IdTipoProducto = data.idTipoProducto,
                StockActual = data.StockActual,
                Precio = data.Precio
            };

            _context.Producto.Add(product);
            _context.SaveChanges();

            return product;
        }
    }
}
