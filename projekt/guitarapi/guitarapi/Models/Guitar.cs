namespace guitarapi.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TypeId { get; set; }
        public virtual GuitarType Type { get; set; }
        public int StringsId { get; set; }
        public virtual Strings Strings { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
