namespace Domain.Entities
{
    public class QuestionSet : BaseEntity
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; } = null!;

        // Navigation Properties
        public Brand? Brand { get; set; }
        public ICollection<Question> Questions { get; set; } = [];
    }
}