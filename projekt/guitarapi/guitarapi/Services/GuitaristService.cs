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

        public bool CreateGuitarist(int guitarId, Guitarist guitarist)
        {
            var guitar = _context.Guitars.Where(g => g.Id == guitarId).FirstOrDefault();

            var guitaristGuitar = new GuitaristGuitar()
            { 
                Guitar = guitar,
                Guitarist = guitarist
            };

            _context.Add(guitaristGuitar);
            _context.Add(guitarist);
            if(_context.SaveChanges() > 0)
                return true;
            return false;

        }

        public bool DeleteGuitarist(Guitarist guitarist)
        {
            _context.Guitarists.Remove(guitarist);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
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
