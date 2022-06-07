using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class GuitarService : IGuitarService
    {
        private readonly DataContext _context;

        public GuitarService(DataContext context)
        {
            _context = context;
        }

        public Guitar GetGuitar(int id)
        {
            return _context.Guitars.Where(g => g.Id == id).Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).FirstOrDefault();
        }

        public ICollection<Guitar> GetGuitars()
        {
            return _context.Guitars.OrderBy(g => g.Id).Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).ToList();
        }
        //
        public ICollection<Guitar> GetGuitarsByProducer(string name)
        {
            return _context.Guitars.Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).Where(p => p.Producer.Name == name).ToList();
        }
        //

        public ICollection<Guitar> GetGuitarsByType(string name)
        {
            throw new NotImplementedException();
        }

        public bool GuitarExists(int id)
        {
            return _context.Guitars.Any(g => g.Id == id);
        }
    }
}
