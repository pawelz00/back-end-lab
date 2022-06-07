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

        public ICollection<Producer> GetProducers()
        {
            return _context.Producers.OrderBy(p => p.Name).ToList();
        }
    }
}
