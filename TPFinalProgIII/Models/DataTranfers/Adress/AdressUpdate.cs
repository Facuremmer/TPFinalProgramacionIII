
namespace TPFinalProgIII.Models.DataTranfers.Adress
{
    public class AdressUpdate
    {
        public virtual int idDireccion { get; set; }
        public virtual long Dni { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Calle { get; set; }
        public virtual int Numero { get; set; }

    }
}
