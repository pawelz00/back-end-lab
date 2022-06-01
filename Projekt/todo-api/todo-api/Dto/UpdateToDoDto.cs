using System.ComponentModel.DataAnnotations;

namespace todo_api.Dto
{
    public class UpdateToDoDto
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
