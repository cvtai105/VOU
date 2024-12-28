using Application.Services.GameServices.Contract;

namespace Application.Services.GameServices.QuizzGame
{
    public class CreateQuizzGameParams : CreateGameParamsAbstract
    {
        public Guid QuestionSetId { get; set; }
        public DateTime StartTime { get; set; }
    }
}