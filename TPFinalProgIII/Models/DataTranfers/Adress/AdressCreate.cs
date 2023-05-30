
namespace TPFinalProgIII.Models.DataTranfers.Adress
{
    public class AdressCreate
    {
        public virtual long idCuit_Dni { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Calle { get; set; }
        public virtual int Numero { get; set; }
    }
}
