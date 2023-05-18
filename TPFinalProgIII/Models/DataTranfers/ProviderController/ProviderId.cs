using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ProviderController
{
    public class ProviderId
    {
        public virtual int idProvider { get; set; }
        public virtual long idCuit_Dni { get; set; }
    }
}
