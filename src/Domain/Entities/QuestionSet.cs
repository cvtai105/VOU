
namespace Domain.Entities
{
    public class QuestionSet
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }

        // Navigation Properties
        public Brand? Brand { get; set; } 
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}