using guitarapi.Data;
using guitarapi.Dto;
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

        public bool AddGuitarToGuitarist(AddGuitarToGuitaristDto dto)
        {
            using (var db = _context)
            {
                var guitarist = db.Guitarists
                    .Include(g => g.GuitaristsGuitars)
                    .Single(g => g.Id == dto.Id);
                var newGuitar = db.Guitars
                    .Single(g => g.Id == dto.guitarId);

                guitarist.GuitaristsGuitars.Add(new GuitaristGuitar
                {
                    Guitarist = guitarist,
                    Guitar = newGuitar
                });
                if (db.SaveChanges() > 0)
                    return true;
            }
            return false;
        }

        public bool DeleteGuitarFromGuitarist(AddGuitarToGuitaristDto dto)
        {
            using (var db = _context)
            {
                var guitaristToUpdate = db.Guitarists.Include(g => g.GuitaristsGuitars).Single(u => u.Id == dto.Id);
                var guitar = db.Guitars.Single(u => u.Id == dto.guitarId);

                guitaristToUpdate.GuitaristsGuitars.Remove(guitaristToUpdate.GuitaristsGuitars.Where(x => x.GuitarId == guitar.Id).FirstOrDefault());
                if(db.SaveChanges() > 0)
                    return true;
            }
            return false;
        }
    }
}
