using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Product;

namespace TPFinalProgIII.Services.Interfaces
{
    //Interfaz
    public interface IProductServices
    {
        //Me devuelve un enumerable de producto
        IEnumerable<Producto> GetAll();
        //Me trae un solo producto
        Producto GetOne(int productId);
        //No devueve nada
        void DeleteProduct(Producto product);
        //Me devuelve un producto actualizado
        Producto UpdateProduct(ProductCreateOrUpdate data);
        //Me devuelve un producto recien creado
        Producto CreateProduct(ProductCreateOrUpdate data);
    }
}
