using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IProducerService
    {
        ICollection<Producer> GetProducers();
        bool CreateProducer(Producer producer);
        Producer GetProducer(int id);
        bool DeleteProducer(Producer producer);
        bool ProducerExists(int id);
    }
}
