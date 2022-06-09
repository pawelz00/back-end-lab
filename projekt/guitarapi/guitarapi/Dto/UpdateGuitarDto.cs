using System.ComponentModel.DataAnnotations;

namespace guitarapi.Dto
{
    public class UpdateGuitarDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "01/01/2022",
        ErrorMessage = "Valid dates for the Property {0} between {1} and {2}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "TypeId between must be between 1 and 5!")]
        public int TypeId { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "StringsId between must be between 1 and 5!")]
        public int StringsId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProducerId { get; set; }
    }
}
