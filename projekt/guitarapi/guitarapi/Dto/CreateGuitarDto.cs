using System.ComponentModel.DataAnnotations;

namespace guitarapi.Dto
{
    public class CreateGuitarDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int StringsId { get; set; }
        [Required]
        public int ProducerId { get; set; }
    }
}
