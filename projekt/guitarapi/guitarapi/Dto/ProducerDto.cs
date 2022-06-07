using guitarapi.Models;

namespace guitarapi.Dto
{
    public class ProducerDto
    {
        public ProducerDto(Producer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
