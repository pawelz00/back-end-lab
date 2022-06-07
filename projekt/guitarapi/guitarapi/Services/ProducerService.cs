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

        public Producer CreateProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
            return producer;
        }

        public ICollection<Producer> GetProducers()
        {
            return _context.Producers.OrderBy(p => p.Name).ToList();
        }
    }
}
