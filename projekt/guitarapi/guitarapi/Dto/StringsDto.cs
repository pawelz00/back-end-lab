using guitarapi.Models;

namespace guitarapi.Dto
{
    public class StringsDto
    {
        public StringsDto(Strings guitarstrings)
        {
            Id = guitarstrings.Id;
            Name = guitarstrings.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
