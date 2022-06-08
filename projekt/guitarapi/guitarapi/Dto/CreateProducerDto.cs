using System.ComponentModel.DataAnnotations;

namespace guitarapi.Dto
{
    public class CreateProducerDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
