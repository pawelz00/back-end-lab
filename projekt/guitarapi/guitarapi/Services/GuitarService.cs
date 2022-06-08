using guitarapi.Data;
using guitarapi.Models;

namespace guitarapi.Services
{
    public class GuitarService : IGuitarService
    {
        private readonly DataContext _context;
        private readonly IProducerService producerService;
        private readonly IStringsService stringsService;
        private readonly IGuitarTypeService guitarTypeService;

        public GuitarService(DataContext context, IProducerService producerService, IStringsService stringsService, IGuitarTypeService guitarTypeService)
        {
            _context = context;
            this.producerService = producerService;
            this.stringsService = stringsService;
            this.guitarTypeService = guitarTypeService;
        }
        public bool CreateGuitar(Guitar guitar)
        {
            _context.Guitars.Add(guitar);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool DeleteGuitar(Guitar guitar)
        {
            _context.Guitars.Remove(guitar);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Guitar GetGuitar(int id)
        {
            return _context.Guitars.Where(g => g.Id == id).Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).FirstOrDefault();
        }

        public ICollection<Guitar> GetGuitars()
        {
            return _context.Guitars.OrderBy(g => g.Id).Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).ToList();
        }
        public ICollection<Guitar> GetGuitarsByProducer(string name)
        {
            return _context.Guitars.Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).Where(p => p.Producer.Name == name).ToList();
        }

        public ICollection<Guitar> GetGuitarsByType(string name)
        {
            return _context.Guitars.Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).Where(p => p.Type.Name == name).ToList();
        }

        public bool GuitarExists(int id)
        {
            return _context.Guitars.Any(g => g.Id == id);
        }

        public bool CheckIfProducerAndTypeAndStringsExists(int producerId, int stringsId, int typeId)
        {
            var producer = producerService.ProducerExists(producerId);
            var strings = stringsService.StringsExists(stringsId);
            var type = guitarTypeService.TypeExists(typeId);

            if (producer == false || strings == false || type == false)
                return false;
            return true;
        }
    }
}
