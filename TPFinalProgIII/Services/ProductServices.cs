using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Product;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ProductServices : BaseServices, IProductServices
    {
        /*private readonly StoreContext _context;
        public ProductServices(StoreContext context)
        {
            _context = context;
        }*/
        public ProductServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Producto> GetAll()
        {
            return _context.Producto.Include(c => c.IdTipoProductoNavigation).ToList();
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
                product.CodigoProducto = data.CodigoProducto;
                product.StockActual = data.StockActual;

                _context.SaveChanges();
            }
            return product;
        }

        public Producto CreateProduct(ProductCreateOrUpdate data)
        {
            var product = new Producto()
            {
                IdProducto = data.idProducto,
                CodigoProducto = data.CodigoProducto,
                IdTipoProducto = data.idTipoProducto,
                StockActual = data.StockActual
            };

            _context.Producto.Add(product);
            _context.SaveChanges();

            return product;
        }
    }
}
