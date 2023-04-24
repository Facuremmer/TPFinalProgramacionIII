using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ShippingSale
{
    public class ShippingSaleCreateOrUpdate
    {
        public virtual int idCodigoDeSeguimiento { get; set; }
        public virtual int idDetalleDeVenta { get; set; }
        public virtual int idDatosEnvioVenta { get; set; }
        public virtual int idDireccion { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Sucursal { get; set; }
    }
}
