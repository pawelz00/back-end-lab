using guitarapi.Models;

namespace guitarapi.Dto
{
    public class GuitaristDto
    {
        public GuitaristDto(Guitarist guitarist)
        {
            Id = guitarist.Id;
            FullName = guitarist.FullName;
            DateOfBirth = guitarist.DateOfBirth;
            Guitars = guitarist.GuitaristsGuitars.Select(g => g.Guitar.Name).ToList();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Guitars { get; set; }
    }
}
