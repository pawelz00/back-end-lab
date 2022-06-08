using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IStringsService
    {
        ICollection<Strings> GetGuitarStrings();
        bool StringsExists(int id);
    }
}
