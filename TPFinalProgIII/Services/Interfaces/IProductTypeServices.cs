using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ProductType;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IProductTypeServices
    {
        IEnumerable<TipoProducto> GetAll();
        TipoProducto GetOne(int productTypeId);
        void DeleteProductType(TipoProducto productType);
        TipoProducto UpdateProductType(ProductTypeDTO data);
        TipoProducto CreateProductType(ProductTypeCreate data);
    }
}
