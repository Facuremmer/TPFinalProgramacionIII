
using System.Collections.Generic;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Product;

namespace TPFinalProgIII.Services.Interfaces
{
    //Interfaz
    public interface IProductServices
    {
        //Me devuelve un enumerable de producto
        IEnumerable<Producto> GetAll();
        IEnumerable<Producto> GetAllId();
        //Me trae un solo producto
        Producto GetOne(int productId);
        IEnumerable<Producto> GetByName(string productName);
        //No devueve nada
        void DeleteProduct(Producto product);
        //Me devuelve un producto actualizado
        Producto UpdateProduct(ProductCreateOrUpdate data);
        //Me devuelve un producto recien creado
        Producto CreateProduct(ProductCreateOrUpdate data);
    }
}
