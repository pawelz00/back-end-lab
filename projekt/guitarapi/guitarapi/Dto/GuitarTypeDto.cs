using guitarapi.Models;

namespace guitarapi.Dto
{
    public class GuitarTypeDto
    {
        public GuitarTypeDto(GuitarType guitartype)
        {
            Id = guitartype.Id;
            Name = guitartype.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
