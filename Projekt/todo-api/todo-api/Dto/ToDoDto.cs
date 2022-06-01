using System.ComponentModel.DataAnnotations;

namespace todo_api.Dto
{
    public class ToDoDto
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
