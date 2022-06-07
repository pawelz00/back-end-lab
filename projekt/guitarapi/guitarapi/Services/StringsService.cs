using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class StringsService : IStringsService
    {
        private readonly DataContext _context;

        public StringsService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Strings> GetGuitarStrings()
        {
            return _context.Strings.OrderBy(s => s.Id).ToList();
        }
    }
}
