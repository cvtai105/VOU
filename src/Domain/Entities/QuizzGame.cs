namespace Domain.Entities
{
    public class QuizzGame : BaseEntity
    {
        public Guid GameId { get; set; }
        public Guid QuestionSetId { get; set; }
        public DateTime StartTime { get; set; }


        // Navigation Properties
        public Game Game { get; set; } = null!;
        public QuestionSet QuestionSet { get; set; } = null!;
    }
}