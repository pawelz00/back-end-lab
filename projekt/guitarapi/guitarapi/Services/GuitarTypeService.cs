using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class GuitarTypeService : IGuitarTypeService
    {
        private readonly DataContext _context;

        public GuitarTypeService(DataContext context)
        {
            _context = context;
        }

        public ICollection<GuitarType> GetGuitarTypes()
        {
            return _context.GuitarTypes.OrderBy(g => g.Id).ToList();
        }
    }
}
