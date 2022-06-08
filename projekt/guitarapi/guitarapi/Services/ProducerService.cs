using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class ProducerService : IProducerService
    {
        private readonly DataContext _context;

        public ProducerService(DataContext context)
        {
            _context = context;
        }

        public bool CreateProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool DeleteProducer(Producer producer)
        {
            _context.Producers.Remove(producer);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Producer GetProducer(int id)
        {
            return _context.Producers.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Producer> GetProducers()
        {
            return _context.Producers.OrderBy(p => p.Name).ToList();
        }

        public bool ProducerExists(int id)
        {
            return _context.Producers.Any(p => p.Id == id);
        }
    }
}
