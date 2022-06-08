using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IGuitaristService
    {
        ICollection<Guitarist> GetGuitarists();
        Guitarist GetGuitarist(int id);
        bool GuitaristExists(int id);
        bool CreateGuitarist(int guitarId, Guitarist guitarist);
    }
}
