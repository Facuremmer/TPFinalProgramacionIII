using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ProductType;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ProductTypeServices : BaseServices, IProductTypeServices
    {
        public ProductTypeServices(StoreContext context)
            : base(context) { }
        public IEnumerable<TipoProducto> GetAll()
        {
            return _context.TipoProducto;
        }

        public TipoProducto GetOne(int productTypeId)
        {
            return _context.TipoProducto.SingleOrDefault(x => x.IdTipoProducto == productTypeId);
        }

        public void DeleteProductType(TipoProducto productType)
        {
            _context.TipoProducto.Remove(productType);
            _context.SaveChanges();
        }

        public TipoProducto UpdateProductType(ProductTypeCreateOrUpdate data)
        {
            var productType = GetOne(data.idTipoProducto);
            if (productType != null)
            {
                productType.Descripcion = data.Descripcion;

                _context.SaveChanges();
            }
            return productType;
        }

        public TipoProducto CreateProductType(ProductTypeCreateOrUpdate data)
        {
            var productType = new TipoProducto()
            {
                Descripcion = data.Descripcion,
            };

            _context.TipoProducto.Add(productType);
            _context.SaveChanges();

            return productType;
        }
    }
}
