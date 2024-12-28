using Domain.Common;

namespace Domain.Entities
{
    public class QuizzGame : GameBase
    {
        public Guid QuestionSetId { get; set; }
        public DateTime StartTime { get; set; }


        // Navigation Properties
        public QuestionSet QuestionSet { get; set; } = null!;
    }
}