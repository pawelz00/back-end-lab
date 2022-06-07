using guitarapi.Models;

namespace guitarapi.Dto
{
    public class GuitarDto
    {
        public GuitarDto(Guitar guitar)
        {
            Id = guitar.Id;
            Name = guitar.Name;
            ReleaseDate = guitar.ReleaseDate;
            Type = guitar.Type.Name;
            Strings = guitar.Strings.Name;
            Producer = guitar.Producer.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public string Strings { get; set; }
        public string Producer { get; set; }
    }
}
