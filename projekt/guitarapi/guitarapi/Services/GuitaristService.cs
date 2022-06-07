using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class GuitaristService : IGuitaristService
    {
        private readonly DataContext _context;
        public GuitaristService(DataContext context)
        {
            _context = context;
        }

        public Guitarist GetGuitarist(int id)
        {
            return _context.Guitarists.Include(g => g.GuitaristsGuitars).ThenInclude(g => g.Guitar).FirstOrDefault(g => g.Id == id);
        }

        public ICollection<Guitarist> GetGuitarists()
        {
            return _context.Guitarists.Include(g => g.GuitaristsGuitars).ThenInclude(g => g.Guitar).ToList();
        }

        public bool GuitaristExists(int id)
        {
            return _context.Guitarists.Any(g => g.Id == id);
        }
    }
}
