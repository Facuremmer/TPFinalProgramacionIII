using AutoMapper;
using TPFinalProgIII.Models.DataTranfers.Adress;
using TPFinalProgIII.Models.DataTranfers.Customer;
using TPFinalProgIII.Models.DataTranfers.Person;
using TPFinalProgIII.Models.DataTranfers.Product;
using TPFinalProgIII.Models.DataTranfers.ProductType;
using TPFinalProgIII.Models.DataTranfers.ProviderController;
using TPFinalProgIII.Models.DataTranfers.Purchase;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;
using TPFinalProgIII.Models.DataTranfers.Sale;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;
using TPFinalProgIII.Models.DataTranfers.ShippingPurchase;
using TPFinalProgIII.Models.DataTranfers.ShippingSale;

namespace TPFinalProgIII.Models.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //De esta manera solo mando estas dos campos que necesito mandar y no todo lo que contiene la tabla producto.
            CreateMap<Producto, ProductDTO>()
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.NombreProducto, opt => opt.MapFrom(o => o.IdTipoProductoNavigation.Descripcion))
                .ForMember(x => x.StockActual, opt => opt.MapFrom(o => o.StockActual))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio));

            CreateMap<Producto, IdProduct>()
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto));

            CreateMap<Producto, ProductId>()
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.idTipoProducto, opt => opt.MapFrom(o => o.IdTipoProducto))
                .ForMember(x => x.NombreProducto, opt => opt.MapFrom(o => o.IdTipoProductoNavigation.Descripcion))
                .ForMember(x => x.StockActual, opt => opt.MapFrom(o => o.StockActual))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio));

            CreateMap<Direccion, AdressDTO>()
                .ForMember(x => x.idDireccion, opt => opt.MapFrom(o => o.IdDireccion))
                .ForMember(x => x.Dni, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni))
                .ForMember(x => x.NombrePersona, opt => opt.MapFrom(o => o.IdCuitDniNavigation.NombreCompleto))
                .ForMember(x => x.Provincia, opt => opt.MapFrom(o => o.Provincia))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(o => o.Ciudad))
                .ForMember(x => x.Calle, opt => opt.MapFrom(o => o.Calle))
                .ForMember(x => x.Numero, opt => opt.MapFrom(o => o.Numero));

            CreateMap<Direccion, AdressUpdate>()
                .ForMember(x => x.Dni, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni))
                .ForMember(x => x.Provincia, opt => opt.MapFrom(o => o.Provincia))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(o => o.Ciudad))
                .ForMember(x => x.Calle, opt => opt.MapFrom(o => o.Calle))
                .ForMember(x => x.Numero, opt => opt.MapFrom(o => o.Numero));

            CreateMap<Direccion, AdressId>()
                .ForMember(x => x.idDireccion, opt => opt.MapFrom(o => o.IdDireccion))
                .ForMember(x => x.Dni, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni));

            CreateMap<Cliente, CustomerDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.IdCliente))
                .ForMember(x => x.DNI, opt => opt.MapFrom(o => o.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.IdCuitDniNavigation.NombreCompleto));

            CreateMap<Cliente, CustomerUpdate>()
                .ForMember(x => x.idCliente, opt => opt.MapFrom(o => o.IdCliente))
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni));

            CreateMap<Persona, PersonDTO>()
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.NombreCompleto));

            CreateMap<Persona, PersonDNI>()
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdCuitDni));

            CreateMap<TipoProducto, ProductTypeDTO>()
                .ForMember(x => x.idTipoProducto, opt => opt.MapFrom(o => o.IdTipoProducto))
                .ForMember(x => x.Descripcion, opt => opt.MapFrom(o => o.Descripcion));

            CreateMap<Proveedor, ProviderDTO>()
                .ForMember(x => x.idProvider, opt => opt.MapFrom(o => o.IdProveedor))
                .ForMember(x => x.DNI, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.IdCuitDniNavigation.NombreCompleto))
                .ForMember(x => x.Rubro, opt => opt.MapFrom(o => o.Rubro));

            CreateMap<Proveedor, ProviderId>()
                .ForMember(x => x.idProvider, opt => opt.MapFrom(o => o.IdProveedor))
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdCuitDniNavigation.IdCuitDni));

            CreateMap<Compra, PurchaseDTO>()
                .ForMember(x => x.idCompra, opt => opt.MapFrom(o => o.IdCompra))
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdProveedorNavigation.IdCuitDniNavigation.IdCuitDni))
                .ForMember(x => x.nombreProveedor, opt => opt.MapFrom(o => o.IdProveedorNavigation.IdCuitDniNavigation.NombreCompleto))
                .ForMember(x => x.idProveedor, opt => opt.MapFrom(o => o.IdProveedorNavigation.IdProveedor))
                .ForMember(x => x.Rubro, opt => opt.MapFrom(o => o.IdProveedorNavigation.Rubro))
                .ForMember(x => x.TotalCompra, opt => opt.MapFrom(o => o.TotalCompra))
                .ForMember(x => x.Fecha, opt => opt.MapFrom(o => o.Fecha));

            CreateMap<Compra, PurchaseId>()
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(o => o.IdProveedorNavigation.IdCuitDniNavigation.NombreCompleto))
                .ForMember(x => x.idCompra, opt => opt.MapFrom(o => o.IdCompra));

            CreateMap<DetalleCompra, PurchaseDetailDTO>()
                .ForMember(x => x.idDetalleCompra, opt => opt.MapFrom(o => o.IdDetalleCompra))
                .ForMember(x => x.idCompra, opt => opt.MapFrom(o => o.IdCompraNavigation.IdCompra))
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Cantidad, opt => opt.MapFrom(o => o.Cantidad))
                .ForMember(x => x.Retencion, opt => opt.MapFrom(o => o.Retencion));

            CreateMap<DetalleCompra, PurchaseDetailId>()
               .ForMember(x => x.idDetalleCompra, opt => opt.MapFrom(o => o.IdDetalleCompra));

            CreateMap<Venta, SaleDTO>()
                .ForMember(x => x.idVenta, opt => opt.MapFrom(o => o.IdVenta))
                .ForMember(x => x.idCliente, opt => opt.MapFrom(o => o.IdCliente))
                .ForMember(x => x.SucursalVenta, opt => opt.MapFrom(o => o.SucursalVenta))
                .ForMember(x => x.Fecha, opt => opt.MapFrom(o => o.Fecha))
                .ForMember(x => x.TotalVenta, opt => opt.MapFrom(o => o.TotalVenta));

            CreateMap<Venta, SaleId>()
                .ForMember(x => x.idVenta, opt => opt.MapFrom(o => o.IdVenta));

            CreateMap<DetalleVenta, SaleDetailDTO>()
                .ForMember(x => x.idDetalleVenta, opt => opt.MapFrom(o => o.IdDetalleVenta))
                .ForMember(x => x.idVenta, opt => opt.MapFrom(o => o.IdVenta))
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Cantidad, opt => opt.MapFrom(o => o.Cantidad))
                .ForMember(x => x.Descuento, opt => opt.MapFrom(o => o.Descuento))
                .ForMember(x => x.Recargo, opt => opt.MapFrom(o => o.Recargo));

            CreateMap<DetalleVenta, SaleDetailId>()
               .ForMember(x => x.idDetalleVenta, opt => opt.MapFrom(o => o.IdDetalleVenta));

            CreateMap<EnvioCompra, ShippingPurchaseDTO>()
                .ForMember(x => x.idCodigoDeSeguimiento, opt => opt.MapFrom(o => o.IdCodigoSeguimiento))
                .ForMember(x => x.idDetalleCompra, opt => opt.MapFrom(o => o.IdDetalleCompra))
                .ForMember(x => x.Correo, opt => opt.MapFrom(o => o.Correo))
                .ForMember(x => x.Sucursal, opt => opt.MapFrom(o => o.Sucursal));

            CreateMap<EnvioVenta, ShippingSaleDTO>()
                .ForMember(x => x.idCodigoDeSeguimiento, opt => opt.MapFrom(o => o.IdCodigoSeguimiento))
                .ForMember(x => x.idDireccion, opt => opt.MapFrom(o => o.IdDireccion))
                .ForMember(x => x.idDetalleDeVenta, opt => opt.MapFrom(o => o.IdDetalleVenta))
                .ForMember(x => x.Correo, opt => opt.MapFrom(o => o.Correo))
                .ForMember(x => x.Sucursal, opt => opt.MapFrom(o => o.Sucursal));
        }
    }
}
