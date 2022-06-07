namespace guitarapi.Models
{
    public class Strings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guitar> Guitars { get; set; }
    }
}
