using System.ComponentModel.DataAnnotations;

namespace todo_api.Dto
{
    public class CreateToDoDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
