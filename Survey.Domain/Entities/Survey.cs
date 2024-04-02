using Survey.Domain.Entities.Base;

namespace Survey.Domain.Entities
{
    public class Survey : Entity
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
