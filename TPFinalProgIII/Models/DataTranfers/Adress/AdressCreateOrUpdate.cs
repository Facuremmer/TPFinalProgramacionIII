using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Adress
{
    public class AdressCreateOrUpdate
    {
        public virtual int idDireccion { get; set; }
        public virtual long idCuit_Dni { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Calle { get; set; }
    }
}
