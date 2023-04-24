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
using TPFinalProgIII.Models.DataTranfers.SaleShippingData;
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
                //PROBAR SI ESTO ANDA.
                .ForMember(x => x.NombreProducto, opt => opt.MapFrom(o => o.IdTipoProductoNavigation.Descripcion))
                .ForMember(x => x.StockActual, opt => opt.MapFrom(o => o.StockActual));

            CreateMap<Direccion, AdressDTO>()
                .ForMember(x => x.Provincia, opt => opt.MapFrom(o => o.Provincia))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(o => o.Ciudad))
                .ForMember(x => x.Calle, opt => opt.MapFrom(o => o.Calle));

            CreateMap<Cliente, CustomerDTO>()
                .ForMember(x => x.DNI, opt => opt.MapFrom(o => o.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.IdCuitDniNavigation.NombreCompleto));

            CreateMap<Persona, PersonDTO>()
                .ForMember(x => x.idCuit_Dni, opt => opt.MapFrom(o => o.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.NombreCompleto));

            CreateMap<TipoProducto, ProductTypeDTO>()
                .ForMember(x => x.Descripcion, opt => opt.MapFrom(o => o.Descripcion));

            CreateMap<Proveedor, ProviderDTO>()
                .ForMember(x => x.DNI, opt => opt.MapFrom(o => o.IdCuitDni))
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.IdCuitDniNavigation.NombreCompleto))
                .ForMember(x => x.Rubro, opt => opt.MapFrom(o => o.Rubro));

            CreateMap<Compra, PurchaseDTO>()
                .ForMember(x => x.TotalCompra, opt => opt.MapFrom(o => o.TotalCompra))
                .ForMember(x => x.Fecha, opt => opt.MapFrom(o => o.Fecha));

            CreateMap<DetalleCompra, PurchaseDetailDTO>()
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Cantidad, opt => opt.MapFrom(o => o.Cantidad))
                .ForMember(x => x.Retencion, opt => opt.MapFrom(o => o.Retencion));

            CreateMap<Venta, SaleDTO>()
                .ForMember(x => x.SucursalVenta, opt => opt.MapFrom(o => o.SucursalVenta))
                .ForMember(x => x.Fecha, opt => opt.MapFrom(o => o.Fecha))
                .ForMember(x => x.TotalVenta, opt => opt.MapFrom(o => o.TotalVenta));

            CreateMap<DetalleVenta, SaleDetailDTO>()
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Cantidad, opt => opt.MapFrom(o => o.Cantidad))
                .ForMember(x => x.Descuento, opt => opt.MapFrom(o => o.Descuento))
                .ForMember(x => x.Recargo, opt => opt.MapFrom(o => o.Recargo));

            CreateMap<DatosEnvioVenta, SaleShippingDataDTO>()
                .ForMember(x => x.NombreCompleto, opt => opt.MapFrom(o => o.NombreCompleto))
                .ForMember(x => x.Provincia, opt => opt.MapFrom(o => o.Provincia))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(o => o.Ciudad))
                .ForMember(x => x.Calle, opt => opt.MapFrom(o => o.Calle))
                .ForMember(x => x.Numero, opt => opt.MapFrom(o => o.Numero))
                .ForMember(x => x.Aclaraciones, opt => opt.MapFrom(o => o.Aclaraciones));

            CreateMap<EnvioCompra, ShippingPurchaseDTO>()
                .ForMember(x => x.idCodigoDeSeguimiento, opt => opt.MapFrom(o => o.IdCodigoSeguimiento))
                .ForMember(x => x.Correo, opt => opt.MapFrom(o => o.Correo))
                .ForMember(x => x.Sucursal, opt => opt.MapFrom(o => o.Sucursal));

            CreateMap<EnvioVenta, ShippingSaleDTO>()
                .ForMember(x => x.idCodigoDeSeguimiento, opt => opt.MapFrom(o => o.IdCodigoSeguimiento))
                .ForMember(x => x.Correo, opt => opt.MapFrom(o => o.Correo))
                .ForMember(x => x.Sucursal, opt => opt.MapFrom(o => o.Sucursal));
        }
    }
}
