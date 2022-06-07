using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IStringsService
    {
        ICollection<Strings> GetGuitarStrings();
    }
}
