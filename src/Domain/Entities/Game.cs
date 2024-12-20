
namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public Guid QuestionSetId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = "";
        public string Description { get; set; } = null!;

        // Navigation Property
        public QuestionSet? QuestionSet { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}