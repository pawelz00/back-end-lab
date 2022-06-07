using guitarapi.Models;

namespace guitarapi.Services
{
    public interface IGuitarTypeService
    {
        ICollection<GuitarType> GetGuitarTypes();
    }
}
