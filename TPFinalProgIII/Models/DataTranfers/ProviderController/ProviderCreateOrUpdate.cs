using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ProviderController
{
    public class ProviderCreateOrUpdate
    {
        public virtual int idProveedor { get; set; }
        public virtual long idCuit_Dni { get; set; }
        public virtual string Rubro { get; set; }
    }
}
