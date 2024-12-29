using Domain.Common;

namespace Domain.Entities
{
    public class QuizzGame : GameBase
    {
        public Guid QuestionSetId { get; set; }
        public int WiningScore { get; set; }

        // Navigation Properties
        public QuestionSet QuestionSet { get; set; } = null!;
    }
}