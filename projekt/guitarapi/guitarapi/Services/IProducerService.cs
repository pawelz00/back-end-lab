using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IProducerService
    {
        ICollection<Producer> GetProducers();
    }
}
