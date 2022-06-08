using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IGuitarService
    {
        Guitar GetGuitar(int id);
        ICollection<Guitar> GetGuitars();
        ICollection<Guitar> GetGuitarsByProducer(string name);
        ICollection<Guitar> GetGuitarsByType(string name);
        bool CreateGuitar(Guitar guitar);
        bool GuitarExists(int id);
        bool DeleteGuitar(Guitar guitar);
        bool CheckIfProducerAndTypeAndStringsExists(int producerId, int stringsId, int typeId);

    }
}
