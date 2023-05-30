
using TPFinalProgIII.Models;

namespace TPFinalProgIII.Services
{
    public class BaseServices
    {
        public readonly StoreContext _context;
         public BaseServices(StoreContext context)
         {
            _context = context;
         }
        
    }
}
