using System.ComponentModel.DataAnnotations;

namespace guitarapi.Dto
{
    public class CreateGuitaristDto
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
