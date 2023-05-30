
namespace TPFinalProgIII.Models.DataTranfers.ProviderController
{
    public class ProviderCreateOrUpdate
    {
        public virtual int idProvider { get; set; }
        public virtual long idCuit_Dni { get; set; }
        public virtual string Rubro { get; set; }
    }
}
