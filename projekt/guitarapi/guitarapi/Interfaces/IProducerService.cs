using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IProducerService
    {
        ICollection<Producer> GetProducers();
        Producer GetProducer(int id);
        bool CreateProducer(Producer producer);
        bool DeleteProducer(Producer producer);
        bool UpdateProducer(Producer producer);
        bool ProducerExists(int id);
    }
}
