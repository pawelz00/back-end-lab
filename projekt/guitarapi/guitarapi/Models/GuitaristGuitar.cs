namespace guitarapi.Models
{
    public class GuitaristGuitar
    {
        public int GuitarId { get; set; }
        public int GuitaristId { get; set; }
        public Guitar Guitar { get; set; }
        public Guitarist Guitarist { get; set; }
    }
}
