using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IGuitarTypeService
    {
        ICollection<GuitarType> GetGuitarTypes();
        bool TypeExists(int id);
    }
}
