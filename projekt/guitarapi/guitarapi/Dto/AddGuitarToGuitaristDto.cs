using guitarapi.Models;
using System.ComponentModel.DataAnnotations;

namespace guitarapi.Dto
{
    public class AddGuitarToGuitaristDto
    {
        [Required]
        public int Id { get; set; }
        public int guitarId { get; set; }
    }
}
