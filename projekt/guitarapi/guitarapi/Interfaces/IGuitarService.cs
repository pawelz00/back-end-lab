using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IGuitarService
    {
        Guitar GetGuitar(int id);
        ICollection<Guitar> GetGuitars();
        ICollection<Guitar> GetGuitarsByProducer(string name);
        ICollection<Guitar> GetGuitarsByType(string name);
        Guitar CreateGuitar(Guitar guitar);
        bool GuitarExists(int id);

    }
}
