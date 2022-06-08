using guitarapi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace guitarapi.Dto
{
    public class ProducerDto
    {
        [JsonConstructor]
        public ProducerDto() { }

        public ProducerDto(Producer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
